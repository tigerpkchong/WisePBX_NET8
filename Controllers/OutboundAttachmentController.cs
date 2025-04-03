using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class OutboundAttachmentController : ControllerBase
    {
        private readonly string fileUploadPath;
        
        
        public OutboundAttachmentController(IConfiguration iConfig, IWebHostEnvironment ienvironment)
        {
            fileUploadPath = iConfig.GetValue<string>("FileUploadPath") ?? "";
            if (fileUploadPath == "")
                fileUploadPath = ienvironment.ContentRootPath + "/Uploads";
        }
        [HttpPost]
        [Route(template: "Outbound/UploadAttachment")]
        public async Task<IActionResult> UploadAttachment(
            [FromForm] int? caseNo, [FromForm] int agentId, [FromForm] int? campaignId, [FromForm] List<IFormFile> files)
        {
            if (files.Count == 0)
                return Ok(new { result = WiseResult.Fail, details = "No File Upload." });
            if (caseNo == null && campaignId == null)
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            string _tmpFolder = ((campaignId == null) ? "C" + caseNo : "O" + campaignId) + "-" + agentId + "-" + DateTime.Now.Ticks;
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
        [Route(template: "Outbound/RemoveAttachment")]
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
