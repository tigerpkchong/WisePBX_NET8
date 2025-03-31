using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
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
        [ActionName("CreateCaseId")]
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
        
        [HttpPost]
        public async Task<IActionResult> UploadAttachment(
            [FromForm] int caseNo, [FromForm] int agentId, [FromForm] int campaignId, [FromForm] List<IFormFile> files)
        {
            if (files.Count == 0)
                return Ok(new { result = WiseResult.Fail, details = "No File Upload." });

            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            string _tmpFolder = ((campaignId == 0) ? "C" + caseNo : "O" + campaignId) + "-" + agentId + "-" + DateTime.Now.Ticks;
            string _fillFolder = Path.Combine(fileUploadPath, _tmpFolder);
            Directory.CreateDirectory(_fillFolder);
            var data = new List<dynamic>();
            foreach (var _file in files)
            {
                string _filePath = Path.Combine(_fillFolder, _file.FileName);
                string _fullfilePath = Path.GetFullPath(_filePath);
                if (_filePath.StartsWith(_fullfilePath, StringComparison.Ordinal))
                {
                    using (Stream fileStream = new FileStream(_fullfilePath, FileMode.Create))
                    {
                        await _file.CopyToAsync(fileStream);
                    }


                    data.Add(new
                    {
                        CreateDateTime = System.IO.File.GetCreationTime(_fullfilePath).ToString("s"),
                        _file.FileName,
                        FilePath = _filePath,
                        _file.ContentType,
                        FileUrl = webUrl + "/Uploads/" + _tmpFolder + "/" + _file.FileName

                    });
                }
            }


            return Ok(new { result = WiseResult.Success, data });
        }

        [HttpPost]
        public IActionResult RemoveAttachment([FromBody] JsonObject p)
        {
            List<string> _folders = [];
            var files = p["files"]?.GetValue<List<string>>();
            if (files != null)
            {
                foreach (string _filepath in files)
                {
                    System.IO.File.Delete(_filepath);
                    string? _folder = Path.GetDirectoryName(_filepath);
                    if (_folder != null && !_folders.Contains(_folder))
                            _folders.Add(_folder);
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
            }
            
            return Ok(new { result = WiseResult.Success });
        }
    }
}
