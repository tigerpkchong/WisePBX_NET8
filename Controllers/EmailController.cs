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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmailController : _MediaController
    {
        private readonly IConfiguration configuration;
        private string hostDrive;
        private string hostName;
        private string hostAddress;
        //private string webUrl;
        private string fileUploadPath;
        private IWebHostEnvironment environment;

        public EmailController(IConfiguration iConfig, IWebHostEnvironment ienvironment)
        {
            environment = ienvironment;
            configuration = iConfig;
            hostDrive = configuration.GetValue<string>("hostDrive") ?? "";
            hostName = configuration.GetValue<string>("HostName") ?? "";
            hostAddress = configuration.GetValue<string>("HostAddress") ?? "";
            //webUrl = configuration.GetValue<string>("WebUrl") ?? "";
            fileUploadPath = configuration.GetValue<string>("FileUploadPath") ?? "";
            if (fileUploadPath == "")
                fileUploadPath = environment.ContentRootPath + "/Uploads";
            
        }

        [HttpPost]
        public IActionResult GetList([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            string dnis = (p["dnis"]??"").ToString();
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());

            if (dnis == "" || agentId <= 0) return Ok(new { result = "fail", details = "Invalid Parameters." });

            WiseEntities _wisedb = new WiseEntities();
            var _mediaList = (from m in _wisedb.MediaCalls
                              where m.AgentID == agentId && m.DNIS == dnis && m.IsHandleFinish == handled
                              && m.CallType == 6
                              select m).ToList();

            Regex _rgx = new Regex("\r?\n");
            var data = new List<dynamic>();
            foreach (MediaCall _medialCall in _mediaList)
            {
                string? _file = _medialCall.Filename?.Replace($@"\\{hostName}\", $@"{hostDrive}:\");
                MimeMessage message = MimeMessage.Load(_file);
                string _content = (message.HtmlBody != null) ? message.HtmlBody : message.TextBody;
                _content = _rgx.Replace(_content.Substring(0, Math.Min(100, _content.Length)), "<br/>");
                data.Add(new 
                {
                    CreateDateTime = _medialCall.ArriveDateTime,
                    EmailID = _medialCall.CallID,
                    Name = message.From[0].Name,
                    Sender = message.From.Mailboxes.Single().Address,
                    Subject = message.Subject ?? "",
                    Content = _content
                });
            }
            return Ok(new { result = "success", data });

        }

        [HttpPost]
        public IActionResult GetCount([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            string dnis = (p["dnis"] ?? "").ToString();
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int handled = Convert.ToInt32((p["handled"] ?? "0").ToString());

            if (dnis == "" || agentId <= 0) return Ok(new { result = "fail", details = "Invalid Parameters." });

            return base.GetCount(6, agentId, dnis, handled);
        }

        [HttpPost]
        public IActionResult GetContent([FromBody] JsonObject p)
        {
            int id =Convert.ToInt32((p["id"]??"0").ToString());
            if (id == 0) return Ok(new { result = "fail", details = "Invalid Parameters." });

            WiseEntities _wisedb = new WiseEntities();
            MediaCall? _mediaCall = (from m in _wisedb.MediaCalls
                                    where m.CallID == id && (m.CallType == 6 || m.CallType == 12)
                                    select m).SingleOrDefault();
            if (_mediaCall == null) return Ok(new { result = "fail", details = "No such record" });


            //dynamic data;
            
            
            string _file = _mediaCall.Filename;
            Regex _rgx = new Regex("\r?\n");
            MimeMessage message = MimeMessage.Load(_file);
            //message.Prepare(EncodingConstraint.SevenBit);
            string _content = (message.HtmlBody != null) ? message.HtmlBody : _rgx.Replace(message.TextBody, "<br/>");
            //_content = WebUtility.HtmlEncode(_content);
            DateTime _timestamp = (_mediaCall.CallType == 12) ? message.Date.LocalDateTime : (DateTime)_mediaCall.ArriveDateTime;
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
                    using (var memoryStream = new MemoryStream())
                    {

                        bodyPart.Content.DecodeTo(memoryStream);
                        byte[] buffer = memoryStream.GetBuffer();

                        //StreamReader reader = new StreamReader(a.Content.Stream);

                        var aa = new 
                        {
                            FileName = bodyPart.FileName,
                            //Base64Data = reader.ReadToEnd(),
                            Base64Data = Convert.ToBase64String(buffer, 0, (int)memoryStream.Length),
                            ContentType = bodyPart.ContentType.MimeType
                        };
                        //reader.Dispose(); 
                        data.Attachments.Add(aa);
                    }

                }
            }
            foreach (MimeEntity entity in message.Attachments)
            {
                MimePart a = entity as MimePart;
                if (a != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {

                        a.Content.DecodeTo(memoryStream);
                        byte[] buffer = memoryStream.GetBuffer();

                        //StreamReader reader = new StreamReader(a.Content.Stream);

                        var aa = new 
                        {
                            FileName = a.FileName,
                            //Base64Data = reader.ReadToEnd(),
                            Base64Data = Convert.ToBase64String(buffer, 0, (int)memoryStream.Length),
                            ContentType = a.ContentType.MimeType
                        };
                        //reader.Dispose(); 
                        data.Attachments.Add(aa);
                    }
                }
                else
                {
                    MessagePart rfc822 = entity as MessagePart;
                    if (rfc822 != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            rfc822.Message.WriteTo(memoryStream);
                            byte[] buffer = memoryStream.GetBuffer();
                            var aa = new 
                            {
                                FileName = rfc822.Message.Subject,
                                //Base64Data = reader.ReadToEnd(),
                                Base64Data = Convert.ToBase64String(buffer, 0, (int)memoryStream.Length),
                                ContentType = rfc822.ContentType.MimeType
                            };
                            //reader.Dispose(); 
                            data.Attachments.Add(aa);
                        }
                    }
                }

            }
            return Ok(new { result = "success", data });
            
        }
        [HttpPost]
        public IActionResult SetHandled([FromBody] JsonObject p)
        {
            int mediaId = Convert.ToInt32((p["mediaId"]??"0").ToString());
            string caseNo = (p["caseNo"] ?? "0").ToString();
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "0").ToString());
            if (mediaId == 0) return Ok(new { result = "fail", details = "Invalid Parameters." });

            return base.SetHandled(6, mediaId, caseNo, updatedBy);
        }

        [HttpPost]
        public IActionResult AssignAgent([FromBody] JsonObject p)
        {
            List<int>? mediaIds = p["mediaIds"]?.GetValue<List<int>>();
            int assignTo = Convert.ToInt32((p["assignTo"]??"0").ToString());
            int updatedBy = Convert.ToInt32((p["updatedBy"] ?? "0").ToString());
            if (mediaIds == null || assignTo <= 0 || updatedBy <= 0)
                return Ok(new { result = "fail", details = "Invalid Parameters." });
            return base.AssignAgent(6, mediaIds, assignTo, updatedBy);

        }

        [HttpPost]
        public IActionResult UploadContent([FromBody] JsonObject p)
        {
            //var httpContext = (HttpContextWrapper)Request.Properties["MS_HttpContext"];

            try
            {
                int agentId = Convert.ToInt32((p["agentId"]??"0").ToString());
                string content = (p["content"] ?? "").ToString();
                string link = (p["link"] ?? "").ToString();

                if (content == "" || agentId == 0)
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                var baseUri = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
                if (link != "")
                {
                    if (link.StartsWith($@"{baseUri}/Uploads/") == false)
                        return Ok(new { result = "fail", details = "Invalid Link Parameters." });

                }
                
                
                string _tmpFolder = DateTime.Today.ToString("yyyyMMdd");
                //string _fillFolder = Path.Combine(environment.WebRootPath ?? environment.ContentRootPath, "Uploads", _tmpFolder);
                string _fillFolder = Path.Combine(fileUploadPath, _tmpFolder);
                Directory.CreateDirectory(_fillFolder);
                string fileName = "Email_" + agentId + "_" + Guid.NewGuid().ToString("N") + ".txt";
                string filePath = Path.Combine(_fillFolder, fileName);
                string fileLink = $@"{baseUri}/Uploads/{_tmpFolder}/{fileName}";

                System.IO.File.WriteAllText(filePath, content, Encoding.Unicode);
                return Ok(new { result = "success", data = new { filePath, fileLink} });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "error", details = ex.Message });
            }

        }

        [HttpPost]
        public IActionResult RemoveContent([FromBody] JsonObject p)
        {
            try
            {
                int agentId = Convert.ToInt32((p["agentId"] ?? "0").ToString());
                string filePath = (p["filePath"]??"").ToString();
                if (filePath == "")
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                string _fileName = Path.GetFileName(filePath);

                if (!_fileName.StartsWith("Email_" + agentId + "_"))
                    return Ok(new { result = "fail", details = "Invalid File Path." });

                System.IO.File.Delete(filePath);
                return Ok(new { result = "success" });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "error", details = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult GetSetting([FromBody] JsonObject p)
        {
            try
            {
                string projectName = (p["projectName"]??"").ToString();

                if (projectName == "")
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                string emailType = (p["emailType"] ?? "").ToString();

                if (emailType != "" && !"Junk Mail,Difficult Customer,Repeated Customer".Split(',').Contains(emailType))
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                string emailAddress = (p["emailAddress"] ?? "").ToString();

                List<EmailSetting>? _setting=null;
                WiseEntities _wisedb = new WiseEntities();
                if (emailAddress == "")
                    _setting =
                    (from m in _wisedb.EmailSettings
                     where m.Valid == "Y" && m.ProjectName == projectName
                     select m).ToList();
                else
                {
                    _setting =
                    (from m in _wisedb.EmailSettings
                     where m.Valid == "Y" && m.ProjectName == projectName
                     && ((m.EmailType == "Junk Mail" && emailAddress.ToLower().Contains((m.EmailAddress.ToLower()))) ||
                     (m.EmailType != "Junk Mail" && emailAddress.ToLower() == m.EmailAddress.ToLower()))
                     select m).ToList();
                }
                if (emailType != "")
                    _setting = _setting.Where(x => x.EmailType == emailType).ToList();
                return Ok(new { result = "success", data = _setting });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "error", details = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult AddSetting([FromBody] JsonObject p)
        {
            try
            {
                string projectName = (p["projectName"] ?? "").ToString();

                if (projectName == "")
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                string emailAddress = (p["emailAddress"] ?? "").ToString();
                if (emailAddress == "")
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                string emailType = (p["emailType"] ?? "").ToString();

                if (emailType == "" || !"Junk Mail,Difficult Customer,Repeated Customer".Split(',').Contains(emailType))
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
                if (agentId == -1)
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                string remarks = (p["remarks"]??"").ToString();
                string fullName = (p["fullName"] ?? "").ToString(); 
                string title = (p["title"] ?? "").ToString();

                WiseEntities _wisedb = new WiseEntities();
                var _setting = (from m in _wisedb.EmailSettings
                                where m.ProjectName == projectName
                                && m.EmailAddress == emailAddress
                                && m.EmailType == emailType
                                select m).SingleOrDefault();
                if (_setting == null)
                {
                    _setting = new EmailSetting();
                    _setting.ProjectName = projectName;
                    _setting.EmailAddress = emailAddress;
                    _setting.EmailType = emailType;
                    _setting.FullName = fullName;
                    _setting.Title = title;
                    _setting.Remarks = remarks;
                    _setting.UpdatedBy = agentId;
                    _setting.UpdateDateTime = DateTime.Now;
                    _setting.Valid = "Y";
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
                        return Ok(new { result = "fail", details = "Such record is already existed." });
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
                return Ok(new { result = "success", data = _setting });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "error", details = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult DelSetting([FromBody] JsonObject p)
        {
            try
            {
                string projectName = (p["projectName"] ?? "").ToString();

                if (projectName == "")
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                string emailAddress = (p["emailAddress"] ?? "").ToString();
                if (emailAddress == "")
                    return Ok(new { result = "fail", details = "Invalid Parameters." });


                string emailType = (p["emailType"] ?? "").ToString();
                if (emailType == "")
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
                if (agentId == -1)
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                WiseEntities _wisedb = new WiseEntities();
                var _setting = (from m in _wisedb.EmailSettings
                                where m.ProjectName == projectName && m.EmailType == emailType
                                && m.EmailAddress == emailAddress && m.Valid == "Y"
                                select m).SingleOrDefault();
                if (_setting == null)
                    return Ok(new { result = "fail", details = "No such record." });


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
                return Ok(new { result = "success" });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "error", details = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult GetJunkMails([FromBody] JsonObject p)
        {
            try
            {
                string projectName = (p["projectName"] ?? "").ToString();

                if (projectName == "")
                    return Ok(new { result = "fail", details = "Invalid Parameters." });



                WiseEntities _wisedb = new WiseEntities();
                var _list =
                    (from m in _wisedb.MediaCalls
                     join l in _wisedb.MediaCall_Action_Logs
                     on m.CallID equals l.CallId
                     where l.Project == projectName && l.Action == "Junk Mail"
                     select m).ToList();

                Regex _rgx = new Regex("\r?\n");
                List<dynamic> _emailList=new List<dynamic>();
                foreach (MediaCall _mediaCall in _list)
                {
                    //string _file = _mediaCall.Filename.Replace(@"\win2016-demo\", @"\172.17.7.40\");
                    string _file = _mediaCall.Filename.Replace($@"\\{hostName}\", $@"{hostDrive}:\");
                    MimeMessage message = MimeMessage.Load(_file);

                    string _content = (message.HtmlBody != null) ? message.HtmlBody : message.TextBody;
                    _content = _rgx.Replace(_content.Substring(0, Math.Min(100, _content.Length)), "<br/>");

                    //MailboxAddress _msgFrom = (MailboxAddress)_msg.MainEntity.From[0];

                    

                    var _email = new 
                    {
                        CreateDateTime = _mediaCall.CreateDateTime,
                        EmailID = _mediaCall.CallID,
                        From = message.From.Mailboxes.Single().Address,
                        To = message.To?.ToString(true) ?? "",
                        Subject = message.Subject ?? "",
                        Body = _content,
                        Attachment = (message.Attachments.Count() == 0) ? "N" : "Y"
                    };
                    
                    _emailList.Add(_email);
                }

                return Ok(new { result = "success", data = _emailList });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "error", details = ex.Message });
            }
        }
    }
}
