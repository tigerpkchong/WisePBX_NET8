using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class OutboundController : ControllerBase
    {
        private readonly string fileUploadPath;
        private readonly WiseEntities _wisedb;

        public OutboundController(IConfiguration iConfig,IWebHostEnvironment ienvironment
            , WiseEntities entities)
        {
            fileUploadPath = iConfig.GetValue<string>("FileUploadPath") ?? "";
            if(fileUploadPath=="")
                fileUploadPath = ienvironment.ContentRootPath + "/Uploads";
            _wisedb = entities;
        }
        [HttpPost]
        [Route(template: "Outbound/GetCallId")]
        public IActionResult GetCallId([FromBody] JsonObject p)
        {
            int callType = (p["callType"] == null) ? 0 : Convert.ToInt32(p["callType"]?.ToString());
            int caseId = (p["caseId"] == null) ? -1 : Convert.ToInt32(p["caseId"]?.ToString());
            int agentId = (p["agentId"] == null) ? -1 : Convert.ToInt32(p["agentId"]?.ToString());
            if (callType==0 || caseId == -1 || agentId == -1)
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
            int _callId = 0, _count = 0;
            do
            {
                _count += 1;
                _callId = (from m in _wisedb.MediaCalls
                           where m.CaseID == caseId && m.CallType == callType
                           && m.AgentID == agentId
                           orderby m.CallID descending
                           select m.CallID).SingleOrDefault();
                if (_callId == 0 && _count <= 7) System.Threading.Thread.Sleep(500);

            } while (_callId == 0 && _count <= 7);
            return Ok(new { result = WiseResult.Success, data = _callId });
        }

        [HttpPost]
        [Route(template: "Outbound/CreateCaseId")]
        public IActionResult CreateCaseId([FromBody] JsonObject p)
        {
            int agentId = (p["agentId"] == null) ? -1 : Convert.ToInt32(p["agentId"]?.ToString());
            if (agentId == -1)
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
            var _objCase = new MediaCall_CaseID
            {
                AgentId = agentId,
                TimeStamp = DateTime.Now
            };
            _wisedb.MediaCall_CaseIDs.Add(_objCase);
            _wisedb.SaveChanges();

            return Ok(new { result = WiseResult.Success, data = _objCase.CaseId });
        }
    }
}
