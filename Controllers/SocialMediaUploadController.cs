using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.SConnector;
using WisePBX.NET8.Models.SConnector_SP;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class SocialMediaUploadController : ControllerBase
    {
        private readonly string fileUploadPath;
        public SocialMediaUploadController(
            IConfiguration iConfig, IWebHostEnvironment iEnv)
        {
            fileUploadPath = iConfig.GetValue<string>("FileUploadPath") ?? "";
            if (fileUploadPath == "")
                fileUploadPath = iEnv.ContentRootPath + "/Uploads";

        }

        [HttpPost]
        [Route(template: "SocialMedia/UploadFile")]
        public async Task<IActionResult> UploadFile(
            [FromForm] string ticketId, [FromForm] int agentId, [FromForm] List<IFormFile> files)
        {
            try
            {
                if (ticketId == string.Empty || agentId == 0)
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
                if (files.Count == 0)
                    return Ok(new { result = WiseResult.Fail, details = "No File Upload." });



                string _fileFolder = Path.Combine(fileUploadPath, DateTime.Today.ToString("yyyyMMdd"), ticketId);
                string _fullfileFolder = Path.GetFullPath(_fileFolder);
                if (_fileFolder.StartsWith(_fullfileFolder, StringComparison.Ordinal))
                {
                    Directory.CreateDirectory(_fullfileFolder);
                }
                //Tiger 2025-04-16 b
                string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

                var data = new List<dynamic>();
                foreach (var _file in files)
                {
                    string _filePath = Path.Combine(_fileFolder, _file.FileName);
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
                            _file.ContentType,
                            _file.FileName,
                            FilePath = _filePath,
                            FileUrl = webUrl + "/Uploads/" + _fileFolder + "/" + _file.FileName
                        });
                    }
                }
                return Ok(new { result = WiseResult.Success, data });
            }
            catch (Exception ex)
            {
                return Ok(new { result = WiseResult.Fail, data = ex.Message });
            }

        }
        
    }

}
