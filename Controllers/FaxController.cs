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
        private readonly IConfiguration configuration;
        private string hostDrive;
        private string hostName;
        private string hostAddress;
        private string webUrl;

        public FaxController(IConfiguration iConfig)
        {
            configuration = iConfig;
            hostDrive = configuration.GetValue<string>("hostDrive") ?? "";
            hostName = configuration.GetValue<string>("HostName") ?? "";
            hostAddress = configuration.GetValue<string>("HostAddress") ?? "";
            webUrl = configuration.GetValue<string>("WebUrl") ?? "";
        }
        [HttpPost]
        [ActionName("GetCount")]
        public IActionResult GetCount([FromBody] dynamic p)
        {
            if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
            string dnis = (p.dnis == null) ? "" : p.dnis.Value;
            int agentId = (p.agentId == null) ? -1 : Convert.ToInt32(p.agentId.Value);
            int handled = (p.handled == null) ? 0 : Convert.ToInt32(p.handled.Value);

            if (dnis == "" || agentId == -1) return Ok(new { result = "fail", details = "Invalid Parameters." });

            return base.GetCount(8, agentId, dnis, handled);
        }

        [HttpPost]
        [ActionName("SetHandled")]
        public IActionResult SetHandled([FromBody] dynamic p)
        {
            int mediaId = (p.mediaId == null) ? 0 : Convert.ToInt32(p.mediaId.Value);
            string caseNo = (p.caseNo == null) ? "0" : Convert.ToString(p.caseNo.Value);
            int updatedBy = (p.updatedBy == null) ? 0 : Convert.ToInt32(p.updatedBy.Value);
            if (mediaId == 0) return Ok(new { result = "fail", details = "Invalid Parameters." });

            return base.SetHandled(8, mediaId, caseNo, updatedBy);
        }

        [HttpPost]
        [ActionName("AssignAgent")]
        public IActionResult AssignAgent([FromBody] dynamic p)
        {
            List<int> mediaIds = ((JArray)p.mediaIds).ToObject<List<int>>();
            int assignTo = (p.assignTo == null) ? -1 : Convert.ToInt32(p.assignTo.Value);
            int updatedBy = (p.updatedBy == null) ? -1 : Convert.ToInt32(p.updatedBy.Value);
            if (mediaIds == null || assignTo == -1 || updatedBy == -1)
                return Ok(new { result = "fail", details = "Invalid Parameters." });

            return base.AssignAgent(8, mediaIds, assignTo, updatedBy);
        }

        [HttpPost]
        [ActionName("GetList")]
        public IActionResult GetList([FromBody] dynamic p)
        {
            if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
            string dnis = (p.dnis == null) ? "" : p.dnis.Value;
            int agentId = (p.agentId == null) ? -1 : Convert.ToInt32(p.agentId.Value);
            int handled = (p.handled == null) ? 0 : Convert.ToInt32(p.handled.Value);

            if (dnis == "" || agentId == -1) return Ok(new { result = "fail", details = "Invalid Parameters." });

            WiseEntities _wisedb = new WiseEntities();

            var _mediaList = (from m in _wisedb.MediaCalls
                              where m.AgentID == agentId && m.DNIS == dnis && m.CallType == 8 &&
                              m.IsHandleFinish == handled
                              orderby m.CreateDateTime descending
                              select m).ToList();



            var data = new List<dynamic>();
            foreach (MediaCall _medialCall in _mediaList)
            {
                string _file = _medialCall.Filename.Replace("\\\\win2016-demo\\", "http://172.17.7.40/wisepbx/").Replace(@"\", @"/");

                data.Add(new 
                {
                    CreateDateTime = (DateTime)_medialCall.CreateDateTime,
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
            if (id == -1) return Ok(new { result = "fail", details = "Invalid Parameters." });

            WiseEntities _wisedb = new WiseEntities();
            MediaCall? _mediaCall = (from m in _wisedb.MediaCalls
                                    where m.CallID == id && (m.CallType == 8 || m.CallType == 13)
                                    select m).SingleOrDefault();
            if (_mediaCall == null) return Ok(new { result = "fail", details = "No such record" });

            string _file = _mediaCall.Filename.Replace("//" + hostName + "/", webUrl + "/").Replace(@"\", @"/");
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
