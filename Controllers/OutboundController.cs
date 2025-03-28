﻿using Microsoft.AspNetCore.Http;
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
        private readonly string strSuccess = "success";
        private readonly string strFail = "fail";
        private readonly string strInvalidParameters = "Invalid Parameters.";

        private readonly string fileUploadPath;

        private readonly WiseEntities _wisedb;

        public OutboundController(IConfiguration iConfig,IWebHostEnvironment ienvironment
            , WiseEntities entities)
        {
            fileUploadPath = iConfig.GetValue<string>("FileUploadPath") ?? "";
            if(fileUploadPath=="")
                fileUploadPath= ienvironment.ContentRootPath + "/Uploads";
            _wisedb = entities;
        }
        [HttpPost]
        public IActionResult GetCallId([FromBody] dynamic p)
        {
            int callType = (p.callType == null) ? 0 : Convert.ToInt32(p.callType.Value);
            int caseId = (p.caseId == null) ? -1 : Convert.ToInt32(p.caseId.Value);
            int agentId = (p.agentId == null) ? -1 : Convert.ToInt32(p.agentId.Value);
            if (caseId == -1 || agentId == -1)
                return Ok(new { result = strFail, details = strInvalidParameters });
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
            return Ok(new { result = strSuccess, data = _callId });
        }

        [HttpPost]
        [ActionName("CreateCaseId")]
        public IActionResult CreateCaseId([FromBody] dynamic p)
        {
            int agentId = (p.agentId == null) ? -1 : Convert.ToInt32(p.agentId.Value);
            if (agentId == -1)
                return Ok(new { result = strFail, details = strInvalidParameters });
            var _objCase = new MediaCall_CaseID
            {
                AgentId = agentId,
                TimeStamp = DateTime.Now
            };
            _wisedb.MediaCall_CaseIDs.Add(_objCase);
            _wisedb.SaveChanges();

            return Ok(new { result = strSuccess, data = _objCase.CaseId });
        }
        public partial record UploadForm
        {
            public required int caseNo { get; init; }
            public required int agentId { get; init; }
            public required int campaignId { get; init; }
            public required List<IFormFile> files { get; init; }
        }
        [HttpPost]
        public async Task<IActionResult> UploadAttachment(UploadForm form)
        {
            if (form.files.Count == 0)
                return Ok(new { result = strFail, details = "No File Upload." });

            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            string _tmpFolder = ((form.campaignId == 0) ? "C" + form.caseNo : "O" + form.campaignId) + "-" + form.agentId + "-" + DateTime.Now.Ticks;
            string _fillFolder = Path.Combine(fileUploadPath, _tmpFolder);
            Directory.CreateDirectory(_fillFolder);
            var data = new List<dynamic>();
            foreach (var _file in form.files)
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


            return Ok(new { result = strSuccess, data });
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
            
            return Ok(new { result = strSuccess });
        }
    }
}
