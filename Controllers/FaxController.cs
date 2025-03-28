using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FaxController : _MediaController
    {
        private readonly string strInvalidParameters = "Invalid Parameters.";
        private readonly string strNoSuchRecord = "No such record.";

        private readonly string hostName;
        
        public FaxController(IConfiguration iConfig)
        {
            hostName = iConfig.GetValue<string>("HostName") ?? "";
        }
        [HttpPost]
        [ActionName("GetCount")]
        public IActionResult GetCount([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "fail", details = strInvalidParameters });
            string dnis = (p["dnis"] ?? "").ToString();
            int agentId = Convert.ToInt32(p["agentId"] ?? "-1");
            int handled = Convert.ToInt32(p["handled"] ?? "0");

            if (dnis == "" || agentId == -1) return Ok(new { result = "fail", details = strInvalidParameters });

            return base.GetCount(8, agentId, dnis, handled);
        }

        [HttpPost]
        [ActionName("SetHandled")]
        public IActionResult SetHandled([FromBody] JsonObject p)
        {
            int mediaId = Convert.ToInt32(p["mediaId"] ?? "0");
            string caseNo = (p["caseNo"] ?? "0").ToString();
            int updatedBy = Convert.ToInt32(p["updatedBy"] ?? "0");
            if (mediaId == 0) return Ok(new { result = "fail", details = strInvalidParameters });

            return base.SetHandled(8, mediaId, caseNo, updatedBy);
        }

        [HttpPost]
        [ActionName("AssignAgent")]
        public IActionResult AssignAgent([FromBody] JsonObject p)
        {
            List<int>? mediaIds = p["mediaIds"]?.GetValue<List<int>>();
            int assignTo = Convert.ToInt32(p["assignTo"] ?? "-1");
            int updatedBy = Convert.ToInt32(p["updatedBy"] ?? "-1");
            if (mediaIds == null || assignTo == -1 || updatedBy == -1)
                return Ok(new { result = "fail", details = strInvalidParameters });

            return base.AssignAgent(8, mediaIds, assignTo, updatedBy);
        }

        [HttpPost]
        [ActionName("GetList")]
        public IActionResult GetList([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "fail", details = strInvalidParameters });
            string dnis = (p["dnis"] ?? "").ToString();
            int agentId = Convert.ToInt32(p["agentId"] ?? "-1");
            int handled = Convert.ToInt32(p["handled"] ?? "0");
            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            if (dnis == "" || agentId == -1) return Ok(new { result = "fail", details = strInvalidParameters });

            WiseEntities _wisedb = new WiseEntities();

            var _mediaList = (from m in _wisedb.MediaCalls
                              where m.AgentID == agentId && m.DNIS == dnis && m.CallType == 8 &&
                              m.IsHandleFinish == handled
                              orderby m.CreateDateTime descending
                              select m).ToList();



            var data = new List<dynamic>();
            foreach (MediaCall _medialCall in _mediaList)
            {
                string _file = (_medialCall.Filename??"").Replace(@"\", @"/").Replace("//" + hostName + "/", webUrl + "/");

                data.Add(new 
                {
                    CreateDateTime = _medialCall.CreateDateTime,
                    FaxID = _medialCall.CallID,
                    CallerDisplay = _medialCall.ANI,
                    FilePath = _file
                });
            }

            return Ok(new { result = "success", data });

        }
        [HttpPost]
        [ActionName("GetContent")]
        public IActionResult GetContent([FromBody] JsonObject p)
        {
            int id = Convert.ToInt32((p["id"]??"-1").ToString());
            if (id == -1) return Ok(new { result = "fail", details = strInvalidParameters });
            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            WiseEntities _wisedb = new WiseEntities();
            MediaCall? _mediaCall = (from m in _wisedb.MediaCalls
                                    where m.CallID == id && (m.CallType == 8 || m.CallType == 13)
                                    select m).SingleOrDefault();
            if (_mediaCall == null) return Ok(new { result = "fail", details = strNoSuchRecord });

            string _file = (_mediaCall.Filename??"").Replace("//" + hostName + "/", webUrl + "/").Replace(@"\", @"/");
            var data = new 
            {
                FileName = Path.GetFileName(_mediaCall.Filename),
                FileUrl = _file,
                CreateDateTime = Convert.ToDateTime(_mediaCall.CreateDateTime),
                CallerDisplay = _mediaCall.ANI
            };
            return Ok(new { result = "success", data });
        }
    }
}
