﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class VmailController(IConfiguration iConfig, WiseEntities wiseEntities) 
        : WiseBaseController(wiseEntities)
    {
        private readonly string hostDrive = iConfig.GetValue<string>("hostDrive") ?? "";
        private readonly string hostName = iConfig.GetValue<string>("HostName") ?? "";
        private readonly string hostAddress = iConfig.GetValue<string>("HostAddress") ?? "";

        private readonly WiseEntities _wisedb = wiseEntities;

        [HttpPost]
        [Route(template: "Vmail/GetCount")]
        public IActionResult GetCount([FromBody] JsonObject p)
        {
            if (p == null) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Vmail.GetCount });
            string dnis = (p["dnis"]??"").ToString();
            int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());

            if (dnis == "" || agentId == -1) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Vmail.GetCount });

            return base.GetCount(7, agentId, dnis, handled);
        }

        [HttpPost]
        [Route(template: "Vmail/GetList")]
        public IActionResult GetList([FromBody] JsonObject p)
        {
            if (p == null) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Vmail.GetList });
            if (p["dnis"] == null) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Vmail.GetList });

            string dnis = (p["dnis"] ?? "").ToString();
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());
            
            var _mediaList = (from m in _wisedb.MediaCalls
                              where (agentId == -1 || m.AgentID == agentId) && m.CallType == 7 &&
                              dnis.Contains((m.DNIS??"")) &&
                              m.IsHandleFinish == handled
                              //&& (read==-1 || m.ReadFlag ==read)
                              //&& (ani == "" || m.ANI == ani)
                              orderby m.CreateDateTime descending
                              select m).ToList();


            List<dynamic> data = [];
            foreach (MediaCall _mediaCall in _mediaList)
            {
                string file = _mediaCall.Filename ?? "";
                if (file.StartsWith(hostDrive + @":\"))
                    file = file.Replace(hostDrive + @":\", @"http://" + hostAddress + @"/wisepbx/").Replace(@"\", @"/");
                else
                    file = file.Replace(@"\" + hostName + @"\", @"\" + hostAddress + @"\");

                data.Add(new 
                {
                    _mediaCall.CreateDateTime,
                    VmailID = _mediaCall.CallID,
                    CallerDisplay = _mediaCall.ANI,
                    _mediaCall.Subject,
                    FilePath = file
                });
            }

            return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Vmail.GetList });

        }

        [HttpPost]
        [Route(template: "Vmail/SetHandled")]
        public IActionResult SetHandled([FromBody] JsonObject p)
        {
            int mediaId = Convert.ToInt32((p[WiseParam.MediaId]??"0").ToString());
            string caseNo = (p["caseNo"] ?? "0").ToString();
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "0").ToString());
            if (mediaId <= 0) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Vmail.SetHandled });

            return base.SetHandled(7, mediaId, caseNo, updatedBy);
        }

        [HttpPost]
        [Route(template: "Vmail/SetRead")]
        public IActionResult SetRead([FromBody] JsonObject p)
        {
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "0").ToString());
            if (p[WiseParam.MediaId] == null)
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Vmail.SetRead });
            if (p[WiseParam.MediaId]?.GetType().Name == "JArray")
            {
                int[]? mediaIds = p[WiseParam.MediaId]?.GetValue<int[]>();
                return base.SetRead(7, (mediaIds ?? []), updatedBy);
            }
            else
            {
                int mediaId = Convert.ToInt32(p[WiseParam.MediaId]?.ToString());
                return base.SetRead(7, mediaId, updatedBy);
            }
        }

        [HttpPost]
        [Route(template: "Vmail/AssignAgent")]
        public IActionResult AssignAgent([FromBody] JsonObject p)
        {

            List<int>? mediaIds = p["mediaIds"]?.GetValue<List<int>>();
            int assignTo = Convert.ToInt32((p["assignTo"]??"-1").ToString());
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "-1").ToString());
            if (mediaIds == null || assignTo == -1 || updatedBy == -1)
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Vmail.AssignAgent });

            return base.AssignAgent(7, mediaIds, assignTo, updatedBy);
        }

        [HttpPost]
        [Route(template: "Vmail/GetContent")]
        public IActionResult GetContent([FromBody] JsonObject p)
        {
            int id = Convert.ToInt32((p["id"]??"-1").ToString());
            if (id <= 0) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Vmail.GetContent });
            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

            var _vmail = (from m in _wisedb.MediaCalls
                          join v in _wisedb.Voicemails on m.PrevCallID equals v.CallID
                          into ps
                          from o in ps.DefaultIfEmpty()
                          where m.CallID == id && m.CallType == 7
                          select new
                          {
                              m.CreateDateTime,
                              m.Subject,
                              CallerDisplay = m.ANI,
                              m.ANI,
                              m.DNIS,
                              StaffNo = m.AgentID,
                              m.IsHandleFinish,
                              m.Filename,
                              FileUrl = (m.Filename??"").Replace(hostDrive + @":\", webUrl + "/").Replace(@"\", @"/"),
                              TimeStamp = m.ArriveDateTime,
                              Duration = m.MediaDuration ?? o.VMDuration ?? 0,
                              m.ReadFlag,
                          }).SingleOrDefault();
            if (_vmail == null) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchRecord, function = WiseFunc.Vmail.GetContent });

            return Ok(new { result = WiseResult.Success, data = _vmail, function = WiseFunc.Vmail.GetContent });
        }

        [HttpPost]
        [Route(template: "Vmail/GetCallId")]
        public IActionResult GetCallId([FromBody] JsonObject p)
        {
            int caseId = Convert.ToInt32((p["caseId"]??"-1").ToString());
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            if (caseId <= 0 || agentId <= 0)
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Vmail.GetCallId });
            return base.GetCallid(12, caseId);
        }
    }
}
