using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route(template: "api/[controller]")]
    [ApiController]
    public class FaxController(IConfiguration iConfig, WiseEntities wiseEntities) 
        : WiseBaseController(wiseEntities)
    {
        private readonly string hostName = iConfig.GetValue<string>("HostName") ?? "";
        private readonly WiseEntities _wisedb = wiseEntities;

        [HttpPost]
        [Route(template: "GetCount")]
        public IActionResult GetCount([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
            string dnis = (p["dnis"] ?? "").ToString();
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());

            if (dnis == "" || agentId == -1) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

            return base.GetCount(8, agentId, dnis, handled);
        }

        [HttpPost]
        [Route(template: "SetHandled")]
        public IActionResult SetHandled([FromBody] JsonObject p)
        {
            int mediaId = Convert.ToInt32((p["mediaId"] ?? "0").ToString());
            string caseNo = (p["caseNo"] ?? "0").ToString();
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "0").ToString());
            if (mediaId == 0) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

            return base.SetHandled(8, mediaId, caseNo, updatedBy);
        }

        [HttpPost]
        [Route(template: "AssignAgent")]
        public IActionResult AssignAgent([FromBody] JsonObject p)
        {
            List<int>? mediaIds = p["mediaIds"]?.GetValue<List<int>>();
            int assignTo = Convert.ToInt32((p["assignTo"] ?? "-1").ToString());
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "-1").ToString());
            if (mediaIds == null || assignTo == -1 || updatedBy == -1)
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

            return base.AssignAgent(8, mediaIds, assignTo, updatedBy);
        }

        [HttpPost]
        [Route(template: "GetList")]
        public IActionResult GetList([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
            string dnis = (p["dnis"] ?? "").ToString();
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());
            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            if (dnis == "" || agentId == -1) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

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
                    _medialCall.CreateDateTime,
                    FaxID = _medialCall.CallID,
                    CallerDisplay = _medialCall.ANI,
                    FilePath = _file
                });
            }

            return Ok(new { result = "success", data });

        }
        [HttpPost]
        [Route(template: "GetContent")]
        public IActionResult GetContent([FromBody] JsonObject p)
        {
            int id = Convert.ToInt32((p["id"]??"-1").ToString());
            if (id == -1) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            
            MediaCall? _mediaCall = (from m in _wisedb.MediaCalls
                                    where m.CallID == id && (m.CallType == 8 || m.CallType == 13)
                                    select m).SingleOrDefault();
            if (_mediaCall == null) return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchRecord });

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
