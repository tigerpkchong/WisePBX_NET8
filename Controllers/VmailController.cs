using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VmailController : _MediaController
    {
        private readonly IConfiguration configuration;
        private readonly string hostDrive;
        private readonly string hostName;
        private readonly string hostAddress;
        public VmailController(IConfiguration iConfig)
        {
            configuration = iConfig;
            hostDrive = configuration.GetValue<string>("hostDrive") ?? "";
            hostName = configuration.GetValue<string>("HostName") ?? "";
            hostAddress = configuration.GetValue<string>("HostAddress") ?? "";
            
        }

        [HttpPost]
        [ActionName("GetCount")]
        public IActionResult GetCount([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
            string dnis = (p["dnis"]??"").ToString();
            int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());

            if (dnis == "" || agentId == -1) return Ok(new { result = "fail", details = "Invalid Parameters." });

            return base.GetCount(7, agentId, dnis, handled);
        }

        [HttpPost]
        [ActionName("GetList")]
        public IActionResult GetList([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
            if (p["dnis"] == null) return Ok(new { result = "fail", details = "Invalid Parameters." });

            string dnis = (p["dnis"] ?? "").ToString();
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());
            
            WiseEntities _wisedb = new WiseEntities();
            var _mediaList = (from m in _wisedb.MediaCalls
                              where (agentId == -1 || m.AgentID == agentId) && m.CallType == 7 &&
                              dnis.Contains((m.DNIS??"")) &&
                              m.IsHandleFinish == handled
                              //&& (read==-1 || m.ReadFlag ==read)
                              //&& (ani == "" || m.ANI == ani)
                              orderby m.CreateDateTime descending
                              select m).ToList();


            List<dynamic> data = new List<dynamic>();
            foreach (MediaCall _mediaCall in _mediaList)
            {
                string file = _mediaCall.Filename ?? "";
                if (file.StartsWith(hostDrive + @":\"))
                    file = file.Replace(hostDrive + @":\", @"http://" + hostAddress + @"/wisepbx/").Replace(@"\", @"/");
                else
                    file = file.Replace(@"\" + hostName + @"\", @"\" + hostAddress + @"\");

                data.Add(new 
                {
                    CreateDateTime = _mediaCall.CreateDateTime,
                    VmailID = _mediaCall.CallID,
                    CallerDisplay = _mediaCall.ANI,
                    Subject = _mediaCall.Subject,
                    FilePath = file
                });
            }

            return Ok(new { result = "success", data });

        }

        [HttpPost]
        [ActionName("SetHandled")]
        public IActionResult SetHandled([FromBody] JsonObject p)
        {
            int mediaId = Convert.ToInt32((p["mediaId"]??"0").ToString());
            string caseNo = (p["caseNo"] ?? "0").ToString();
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "0").ToString());
            if (mediaId <= 0) return Ok(new { result = "fail", details = "Invalid Parameters." });

            return base.SetHandled(7, mediaId, caseNo, updatedBy);
        }

        [HttpPost]
        public IActionResult SetRead([FromBody] JsonObject p)
        {
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "0").ToString());
            if (p["mediaId"] == null)
                return Ok(new { result = "fail", details = "Invalid Parameters." });
            if (p["mediaId"]?.GetType().Name == "JArray")
            {
                int[]? mediaIds = p["mediaId"]?.GetValue<int[]>();
                return base.SetRead(7, (mediaIds ?? []), updatedBy);
            }
            else
            {
                int mediaId = Convert.ToInt32(p["mediaId"].ToString());
                return base.SetRead(7, mediaId, updatedBy);
            }
        }

        [HttpPost]
        [ActionName("AssignAgent")]
        public IActionResult AssignAgent([FromBody] JsonObject p)
        {

            List<int> mediaIds = p["mediaIds"].GetValue<List<int>>();
            int assignTo = Convert.ToInt32((p["assignTo"]??"-1").ToString());
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "-1").ToString());
            if (mediaIds == null || assignTo == -1 || updatedBy == -1)
                return Ok(new { result = "fail", details = "Invalid Parameters." });

            return base.AssignAgent(7, mediaIds, assignTo, updatedBy);
        }

        [HttpPost]
        [ActionName("GetContent")]
        public IActionResult GetContent([FromBody] JsonObject p)
        {
            int id = Convert.ToInt32((p["id"]??"-1").ToString());
            if (id <= 0) return Ok(new { result = "fail", details = "Invalid Parameters." });
            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

            WiseEntities _wisedb = new WiseEntities();

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
                              FileUrl = m.Filename.Replace(hostDrive + @":\", webUrl + "/").Replace(@"\", @"/"),
                              TimeStamp = m.ArriveDateTime,
                              Duration = m.MediaDuration ?? o.VMDuration ?? 0,
                              m.ReadFlag,
                          }).SingleOrDefault();
            if (_vmail == null) return Ok(new { result = "fail", details = "No such record" });

            return Ok(new { result = "success", data = _vmail });
        }

        [HttpPost]
        public IActionResult GetCallId([FromBody] JsonObject p)
        {
            int caseId = Convert.ToInt32((p["caseId"]??"-1").ToString());
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            if (caseId <= 0 || agentId <= 0)
                return Ok(new { result = "fail", details = "Invalid Parameters." });
            return base.GetCallid(12, caseId, agentId);
        }
    }
}
