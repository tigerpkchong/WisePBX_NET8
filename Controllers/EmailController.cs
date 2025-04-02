using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Hosting.Internal;
using MimeKit;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Mail;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Xml;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class EmailController : WiseBaseController
    {
        private readonly string hostDrive;
        private readonly string hostName;
        private readonly string fileUploadPath;

        private readonly WiseEntities _wisedb;
        public EmailController(IConfiguration iConfig, IWebHostEnvironment ienvironment
            , WiseEntities wiseEntities) 
            : base( wiseEntities)
        {
            hostDrive = iConfig.GetValue<string>("hostDrive") ?? "";
            hostName = iConfig.GetValue<string>("HostName") ?? "";
            fileUploadPath = iConfig.GetValue<string>("FileUploadPath") ?? "";
            if (fileUploadPath == "")
                fileUploadPath = ienvironment.ContentRootPath + "/Uploads";
            _wisedb = wiseEntities;
        }

        [HttpPost]
        [Route(template: "Email/GetList")]
        public IActionResult GetList([FromBody] JsonObject p)
        {
            string dnis = (p["dnis"]??"").ToString();
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());

            if (dnis == "" || agentId <= 0) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.GetList });

            var _mediaList = (from m in _wisedb.MediaCalls
                              where m.AgentID == agentId && m.DNIS == dnis && m.IsHandleFinish == handled
                              && m.CallType == 6
                              select m).Take(1000).ToList();

            Regex _rgx = new("\r?\n");
            var data = new List<dynamic>();
            foreach (MediaCall _medialCall in _mediaList)
            {
                string? _file = _medialCall.Filename?.Replace($@"\\{hostName}\", $@"{hostDrive}:\");
                MimeMessage message = MimeMessage.Load(_file);
                string _content = message.HtmlBody??message.TextBody;
                _content = _rgx.Replace(_content[..Math.Min(100, _content.Length)], "<br/>");
                data.Add(new 
                {
                    CreateDateTime = _medialCall.ArriveDateTime,
                    EmailID = _medialCall.CallID,
                    message.From[0].Name,
                    Sender = message.From.Mailboxes.Single().Address,
                    Subject = message.Subject ?? "",
                    Content = _content
                });
            }
            return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Email.GetList });

        }

        [HttpPost]
        [Route(template: "Email/GetCount")]
        public IActionResult GetCount([FromBody] JsonObject p)
        {
            string dnis = (p["dnis"] ?? "").ToString();
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());

            if (dnis == "" || agentId <= 0) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.GetCount });
            return base.GetCount(6, agentId, dnis, handled);
        }

        [HttpPost]
        [Route(template: "Email/GetContent")]
        public IActionResult GetContent([FromBody] JsonObject p)
        {
            int id =Convert.ToInt32((p["id"]??"0").ToString());
            if (id == 0) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.GetContent });

            MediaCall? _mediaCall = (from m in _wisedb.MediaCalls
                                    where m.CallID == id && (m.CallType == 6 || m.CallType == 12)
                                    select m).SingleOrDefault();
            if (_mediaCall == null) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchRecord, function = WiseFunc.Email.GetContent });


            
            string _file = _mediaCall.Filename??"";
            Regex _rgx = new("\r?\n");
            MimeMessage message = MimeMessage.Load(_file);
            string _content = message.HtmlBody??_rgx.Replace(message.TextBody, "<br/>");
            DateTime _timestamp = (_mediaCall.CallType == 12) ? message.Date.LocalDateTime : 
                _mediaCall.ArriveDateTime?? message.Date.LocalDateTime;
            var data = new
            {
                From = (message.From.Count == 0) ? "" : message.From.Mailboxes.Single().Address,
                To = message.To?.ToString(true) ?? "",
                Cc = message.Cc?.ToString(true) ?? "",
                Bcc = _mediaCall.BCC,
                Subject = message.Subject ?? "",
                Body = _content,
                TimeStamp = _timestamp.ToString("s"),
                Attachments = new List<dynamic>()
            };
            foreach (MimePart bodyPart in message.BodyParts.OfType<MimePart>())
            {
                if (bodyPart.FileName != null && !bodyPart.IsAttachment)
                {
                    using var memoryStream = new MemoryStream();
                    
                    bodyPart.Content.DecodeTo(memoryStream);
                    byte[] buffer = memoryStream.GetBuffer();

                    var aa = new 
                    {
                        bodyPart.FileName,
                        Base64Data = Convert.ToBase64String(buffer, 0, (int)memoryStream.Length),
                        ContentType = bodyPart.ContentType.MimeType
                    };
                    data.Attachments.Add(aa);
                }
            }
            foreach (MimeEntity entity in message.Attachments)
            {
                if (entity is MimePart mimePart)
                {
                    using var memoryStream = new MemoryStream();

                    mimePart.Content.DecodeTo(memoryStream);
                    byte[] buffer = memoryStream.GetBuffer();

                    var attachment = new
                    {
                        mimePart.FileName,
                        Base64Data = Convert.ToBase64String(buffer, 0, (int)memoryStream.Length),
                        ContentType = mimePart.ContentType.MimeType
                    };
                    data.Attachments.Add(attachment);

                }
                else
                {
                    if (entity is MessagePart msgPart)
                    {
                        using var memoryStream = new MemoryStream();
                        msgPart.Message.WriteTo(memoryStream);
                        byte[] buffer = memoryStream.GetBuffer();
                        var attachment = new
                        {
                            FileName = msgPart.Message.Subject,
                            Base64Data = Convert.ToBase64String(buffer, 0, (int)memoryStream.Length),
                            ContentType = msgPart.ContentType.MimeType
                        };
                        data.Attachments.Add(attachment);
                    }
                }

            }
            return Ok(new { result = WiseResult.Success, data, WiseFunc.Email.GetContent });
            
        }
        [HttpPost]
        [Route(template: "Email/SetHandled")]
        public IActionResult SetHandled([FromBody] JsonObject p)
        {
            int mediaId = Convert.ToInt32((p["mediaId"]??"0").ToString());
            string caseNo = (p["caseNo"] ?? "0").ToString();
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "0").ToString());
            if (mediaId == 0) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.SetHandled });

            return base.SetHandled(6, mediaId, caseNo, updatedBy);
        }

        [HttpPost]
        [Route(template: "Email/AssignAgent")]
        public IActionResult AssignAgent([FromBody] JsonObject p)
        {
            List<int>? mediaIds = p["mediaIds"]?.GetValue<List<int>>();
            int assignTo = Convert.ToInt32((p["assignTo"]??"0").ToString());
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "0").ToString());
            if (mediaIds == null || assignTo <= 0 || updatedBy <= 0)
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.AssignAgent });
            return base.AssignAgent(6, mediaIds, assignTo, updatedBy);

        }

        [HttpPost]
        [Route(template: "Email/UploadContent")]
        public IActionResult UploadContent([FromBody] JsonObject p)
        {
            try
            {
                int agentId = Convert.ToInt32((p["agentId"]??"0").ToString());
                string content = (p["content"] ?? "").ToString();
                string link = (p["link"] ?? "").ToString();
                string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

                if (content == "" || agentId == 0)
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.UploadContent });

                if (link != "" && !link.StartsWith($@"{webUrl}/Uploads/"))
                {
                    return Ok(new { result = WiseResult.Fail, details = "Invalid Link Parameters.", function = WiseFunc.Email.UploadContent });
                }

                string _tmpFolder = DateTime.Today.ToString("yyyyMMdd");
                string _fillFolder = Path.Combine(fileUploadPath, _tmpFolder);
                Directory.CreateDirectory(_fillFolder);
                string fileName = "Email_" + agentId + "_" + Guid.NewGuid().ToString("N") + ".txt";
                string filePath = Path.Combine(_fillFolder, fileName);
                string fileLink = $@"{webUrl}/Uploads/{_tmpFolder}/{fileName}";

                System.IO.File.WriteAllText(filePath, content, Encoding.Unicode);
                return Ok(new { result = WiseResult.Success, data = new { filePath, fileLink}, function = WiseFunc.Email.UploadContent });
            }
            catch (Exception ex)
            {
                return Ok(new { result = WiseResult.Error, details = ex.Message, function = WiseFunc.Email.UploadContent });
            }

        }

        [HttpPost]
        [Route(template: "Email/RemoveContent")]
        public IActionResult RemoveContent([FromBody] JsonObject p)
        {
            try
            {
                int agentId = Convert.ToInt32((p["agentId"] ?? "0").ToString());
                string filePath = (p["filePath"]??"").ToString();
                if (filePath == "")
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.RemoveContent });

                string _fileName = Path.GetFileName(filePath);

                if (!_fileName.StartsWith("Email_" + agentId + "_"))
                    return Ok(new { result = WiseResult.Fail, details = "Invalid File Path.", function = WiseFunc.Email.RemoveContent });

                System.IO.File.Delete(filePath);
                return Ok(new { result = WiseResult.Success });
            }
            catch (Exception ex)
            {
                return Ok(new { result = WiseResult.Error, details = ex.Message, function = WiseFunc.Email.RemoveContent });
            }
        }

        [HttpPost]
        [Route(template: "Email/GetSetting")]
        public IActionResult GetSetting([FromBody] JsonObject p)
        {
            try
            {
                string projectName = (p["projectName"]??"").ToString();

                if (projectName == "")
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.GetSetting });

                string emailType = (p["emailType"] ?? "").ToString();

                if (emailType != "" && !"Junk Mail,Difficult Customer,Repeated Customer".Split(',').Contains(emailType))
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.GetSetting });

                string emailAddress = (p["emailAddress"] ?? "").ToString();

                IEnumerable<EmailSetting>? _setting=null;
                if (emailAddress == "")
                    _setting =
                    (from m in _wisedb.EmailSettings
                     where m.Valid == "Y" && m.ProjectName == projectName
                     select m).AsEnumerable();
                else
                {
                    _setting =
                    (from m in _wisedb.EmailSettings
                     where m.Valid == "Y" && m.ProjectName == projectName
                     && ((m.EmailType == "Junk Mail" && emailAddress.Contains(m.EmailAddress, StringComparison.OrdinalIgnoreCase)) ||
                     (m.EmailType != "Junk Mail" && emailAddress.Equals(m.EmailAddress, StringComparison.OrdinalIgnoreCase)))
                     select m).AsEnumerable();
                }
                if (emailType != "")
                    _setting = _setting.Where(x => x.EmailType == emailType).AsEnumerable();
                return Ok(new { result = WiseResult.Success, data = _setting });
            }
            catch (Exception ex)
            {
                return Ok(new { result = WiseResult.Error, details = ex.Message, function = WiseFunc.Email.GetSetting });
            }
        }

        [HttpPost]
        [Route(template: "Email/AddSetting")]
        public IActionResult AddSetting([FromBody] JsonObject p)
        {
            try
            {
                string projectName = (p["projectName"] ?? "").ToString();
                string emailAddress = (p["emailAddress"] ?? "").ToString();
                string emailType = (p["emailType"] ?? "").ToString();
                int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
                if (projectName == "" || emailAddress == "" || agentId == -1)
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.AddSetting });

                

                if (emailType == "" || !"Junk Mail,Difficult Customer,Repeated Customer".Split(',').Contains(emailType))
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.AddSetting });

                string remarks = (p["remarks"]??"").ToString();
                string fullName = (p["fullName"] ?? "").ToString(); 
                string title = (p["title"] ?? "").ToString();

                var _setting = (from m in _wisedb.EmailSettings
                                where m.ProjectName == projectName
                                && m.EmailAddress == emailAddress
                                && m.EmailType == emailType
                                select m).SingleOrDefault();
                if (_setting == null)
                {
                    _setting = new EmailSetting
                    {
                        ProjectName = projectName,
                        EmailAddress = emailAddress,
                        EmailType = emailType,
                        FullName = fullName,
                        Title = title,
                        Remarks = remarks,
                        UpdatedBy = agentId,
                        UpdateDateTime = DateTime.Now,
                        Valid = "Y"
                    };
                    _wisedb.EmailSettings.Add(_setting);

                }
                else
                {
                    if (_setting.Valid == "N")
                    {
                        _setting.Valid = "Y";
                        _setting.EmailType = emailType;
                        _setting.FullName = fullName;
                        _setting.Title = title;
                        _setting.Remarks = remarks;
                        _setting.UpdatedBy = agentId;
                        _setting.UpdateDateTime = DateTime.Now;

                    }
                    else
                        return Ok(new { result = WiseResult.Fail, details = "Such record is already existed.", function = WiseFunc.Email.AddSetting });
                }


                _wisedb.EmailSetting_Logs.Add(new EmailSetting_Log()
                {
                    ProjectName = _setting.ProjectName,
                    EmailAddress = _setting.EmailAddress,
                    EmailType = _setting.EmailType,
                    FullName = _setting.FullName,
                    Title = _setting.Title,
                    Remarks = _setting.Remarks,
                    UpdatedBy = _setting.UpdatedBy,
                    UpdateDateTime = _setting.UpdateDateTime,
                    Valid = _setting.Valid
                });

                _wisedb.SaveChanges();
                return Ok(new { result = WiseResult.Success, data = _setting, function = WiseFunc.Email.AddSetting });
            }
            catch (Exception ex)
            {
                return Ok(new { result = WiseResult.Fail, details = ex.Message, function = WiseFunc.Email.AddSetting });
            }
        }

        [HttpPost]
        [Route(template: "Email/DelSetting")]
        public IActionResult DelSetting([FromBody] JsonObject p)
        {
            try
            {
                string projectName = (p["projectName"] ?? "").ToString();
                string emailAddress = (p["emailAddress"] ?? "").ToString();
                string emailType = (p["emailType"] ?? "").ToString();
                int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
                if (projectName == "" || emailAddress == "" || emailType == "" || agentId == -1)
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.DelSetting });
                
                var _setting = (from m in _wisedb.EmailSettings
                                where m.ProjectName == projectName && m.EmailType == emailType
                                && m.EmailAddress == emailAddress && m.Valid == "Y"
                                select m).SingleOrDefault();
                if (_setting == null)
                    return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchRecord, function = WiseFunc.Email.DelSetting });


                _setting.Valid = "N";
                _setting.UpdatedBy = agentId;
                _setting.UpdateDateTime = DateTime.Now;

                _wisedb.EmailSetting_Logs.Add(new EmailSetting_Log()
                {
                    ProjectName = _setting.ProjectName,
                    EmailAddress = _setting.EmailAddress,
                    EmailType = _setting.EmailType,
                    UpdatedBy = _setting.UpdatedBy,
                    UpdateDateTime = _setting.UpdateDateTime,
                    Valid = _setting.Valid
                });

                _wisedb.SaveChanges();
                return Ok(new { result = WiseResult.Success, function = WiseFunc.Email.DelSetting });
            }
            catch (Exception ex)
            {
                return Ok(new { result = WiseResult.Fail, details = ex.Message, function = WiseFunc.Email.DelSetting });
            }
        }

        [HttpPost]
        [Route(template: "Email/GetJunkMails")]
        public IActionResult GetJunkMails([FromBody] JsonObject p)
        {
            try
            {
                string projectName = (p["projectName"] ?? "").ToString();

                if (projectName == "")
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Email.GetJunkMails });



                var _list =
                    (from m in _wisedb.MediaCalls
                     join l in _wisedb.MediaCall_Action_Logs
                     on m.CallID equals l.CallId
                     where l.Project == projectName && l.Action == "Junk Mail"
                     select m).ToList();

                Regex _rgx = new("\r?\n");
                List<dynamic> _emailList=[];
                foreach (MediaCall _mediaCall in _list)
                {
                    string _file = (_mediaCall.Filename??"").Replace($@"\\{hostName}\", $@"{hostDrive}:\");
                    MimeMessage message = MimeMessage.Load(_file);

                    string _content = message.HtmlBody??message.TextBody;
                    _content = _rgx.Replace(_content[..Math.Min(100, _content.Length)], "<br/>");

                    
                    var _email = new 
                    {
                        _mediaCall.CreateDateTime,
                        EmailID = _mediaCall.CallID,
                        From = message.From.Mailboxes.Single().Address,
                        To = message.To?.ToString(true) ?? "",
                        Subject = message.Subject ?? "",
                        Body = _content,
                        Attachment = message.Attachments.Any() ? "Y" : "N"
                    };
                    
                    _emailList.Add(_email);
                }

                return Ok(new { result = WiseResult.Success, data = _emailList, function = WiseFunc.Email.GetJunkMails });
            }
            catch (Exception ex)
            {
                return Ok(new { result = WiseResult.Fail, details = ex.Message, function = WiseFunc.Email.GetJunkMails });
            }
        }
    }
}
