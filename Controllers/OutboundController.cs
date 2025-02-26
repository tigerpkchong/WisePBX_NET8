using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OutboundController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private string hostDrive;
        private string hostName;
        private string hostAddress;
        //private string webUrl;
        private string fileUploadPath;
        private IWebHostEnvironment environment;
        public OutboundController(IConfiguration iConfig,IWebHostEnvironment ienvironment)
        {
            environment = ienvironment;
            configuration = iConfig;
            hostDrive = configuration.GetValue<string>("hostDrive") ?? "";
            hostName = configuration.GetValue<string>("HostName") ?? "";
            hostAddress = configuration.GetValue<string>("HostAddress") ?? "";
            //webUrl = configuration.GetValue<string>("WebUrl") ?? "";
            fileUploadPath = configuration.GetValue<string>("FileUploadPath") ?? "";
            if(fileUploadPath=="")
                fileUploadPath=environment.ContentRootPath + "/Uploads";
        }
        [HttpPost]
        public IActionResult GetCallId([FromBody] dynamic p)
        {
            int callType = (p.callType == null) ? 0 : Convert.ToInt32(p.callType.Value);
            int caseId = (p.caseId == null) ? -1 : Convert.ToInt32(p.caseId.Value);
            int agentId = (p.agentId == null) ? -1 : Convert.ToInt32(p.agentId.Value);
            if (caseId == -1 || agentId == -1)
                return Ok(new { result = "fail", details = "Invalid Parameters." });
            WiseEntities _wisedb = new WiseEntities();
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
            return Ok(new { result = "success", data = _callId });
        }

        [HttpPost]
        [ActionName("CreateCaseId")]
        public IActionResult CreateCaseId([FromBody] dynamic p)
        {
            int agentId = (p.agentId == null) ? -1 : Convert.ToInt32(p.agentId.Value);
            if (agentId == -1)
                return Ok(new { result = "fail", details = "Invalid Parameters." });
            WiseEntities _wisedb = new WiseEntities();
            var _objCase = new MediaCall_CaseID
            {
                AgentId = agentId,
                TimeStamp = DateTime.Now
            };
            _wisedb.MediaCall_CaseIDs.Add(_objCase);
            _wisedb.SaveChanges();

            return Ok(new { result = "success", data = _objCase.CaseId });
        }

        [HttpPost]
        public async Task<IActionResult> UploadAttachment()
        {
            //var httpContext = (HttpContextWrapper)Request.Properties["MS_HttpContext"];
            var form = HttpContext.Request.Form;
            
            if ((form["caseNo"] == "" && form["agentId"] == "") || form["campaignId"] == "")
                return Ok(new { result = "fail", details = "Invalid Parameters." });
            int caseNo = Convert.ToInt32(form["caseNo"]);
            int agentId = Convert.ToInt32(form["agentId"]);
            int campaignId = Convert.ToInt32(form["campaignId"]);
            
            if (form.Files.Count == 0)
                return Ok(new { result = "fail", details = "No File Upload." });
            
            string _tmpFolder = ((campaignId == 0) ? "C" + caseNo : "O" + campaignId) + "-" + agentId + "-" + DateTime.Now.Ticks; //+ Guid.NewGuid().ToString();
            string _fillFolder = Path.Combine(fileUploadPath, "Uploads", _tmpFolder);
            Directory.CreateDirectory(_fillFolder);
            var files = HttpContext.Request.Form.Files;
            var baseUri = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            var data = new List<dynamic>();
            foreach (var _file in files)
            {
                string _filePath = Path.Combine(_fillFolder, _file.FileName);
                using (Stream fileStream = new FileStream(_filePath, FileMode.Create))
                {
                    await _file.CopyToAsync(fileStream);
                }
                data.Add(new 
                {
                    CreateDateTime = ((DateTime) System.IO.File.GetCreationTime(_filePath)).ToString("s"),
                    FileName = _file.FileName,
                    FilePath = _filePath,
                    ContentType = _file.ContentType,
                    FileUrl = baseUri + "/Uploads/" + _tmpFolder + "/" + _file.FileName

                });
            }


            return Ok(new { result = "success", data });
        }

        [HttpPost]
        public IActionResult RemoveAttachment([FromBody] JsonObject p)
        {
            List<string> _folders = new List<string>();
            foreach (string _filepath in p["files"].GetValue<List<string>>())
            {
                System.IO.File.Delete(_filepath);
                string _folder = Path.GetDirectoryName(_filepath);
                if (!_folders.Contains(_folder)) _folders.Add(_folder);
            }
            foreach (string _folder in _folders)
            {
                try
                {
                    Directory.Delete(_folder, false);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }


            }
            return Ok(new { result = "success" });
        }
    }
}
