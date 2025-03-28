﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.SConnector;
using WisePBX.NET8.Models.SConnector_SP;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly string strSuccess = "success";
        private readonly string strFail = "fail";
        private readonly string strError = "error";
        private readonly string strInvalidParameters = "Invalid Parameters.";

        private readonly WiseEntities _wiseDB;
        private readonly SConnectorEntities _sconnDB;
        private readonly SConnectorSPEntities _sconnSPDB;
        private readonly string hostAddress;
        private readonly string fileUploadPath;
        public SocialMediaController(IConfiguration iConfig, IWebHostEnvironment ienv, 
            WiseEntities wEntities,
            SConnectorEntities sEntities, SConnectorSPEntities sEntitiesSP)
        {
            _wiseDB = wEntities;
            _sconnDB = sEntities;
            _sconnSPDB = sEntitiesSP;
            hostAddress = iConfig.GetValue<string>("HostAddress") ?? "";
            fileUploadPath = iConfig.GetValue<string>("FileUploadPath") ?? "";
            if (fileUploadPath == "")
                fileUploadPath = ienv.ContentRootPath + "/Uploads";
        }

        public partial record UploadForm
        {
            public required string ticketId { get; init; }
            public required int agentId { get; init; }
            public required List<IFormFile> files { get; init; }
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadForm form)
        {
            try
            {
                string ticketId = form.ticketId;
                int agentId = form.agentId;

                if (ticketId == string.Empty || agentId == 0)
                    return Ok(new { result = strFail, details = strInvalidParameters });
                if (form.files.Count == 0)
                    return Ok(new { result = strFail, details = "No File Upload." });

                
                string _fileFolder = Path.Combine(fileUploadPath, DateTime.Today.ToString("yyyyMMdd"), ticketId);
                string _fullfileFolder = Path.GetFullPath(_fileFolder);
                if (_fileFolder.StartsWith(_fullfileFolder, StringComparison.Ordinal))
                {
                    Directory.CreateDirectory(_fullfileFolder);
                }
                string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

                var data = new List<dynamic>();
                foreach (var _file in form.files)
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
                return Ok(new { result = strSuccess, data });
            }
            catch (Exception ex)
            {
                return Ok(new { result = strFail, data = ex.Message });
            }

        }

        [HttpPost]
        public IActionResult GetPreviousTicketId([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = strError, details = strInvalidParameters });
                string userId = (p["userId"] ?? "").ToString();
                string entry = (p["entry"] ?? "").ToString();
                string companyCode = (p["companyCode"] ?? "").ToString();
                long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());

                string? _time = (from m in _sconnDB.SC_Tickets
                                 where m.enduser_id == userId && m.entry == entry
                                 && m.ticket_id == ticketId && m.company_code == companyCode
                                 select m.start_time).SingleOrDefault();
                if (_time == null) return Ok(new { result = strError, details = "Invalid Ticket No." });

                var _list = (from m in _sconnDB.SC_Tickets
                             where m.enduser_id == userId && m.entry == entry
                             && (m.start_time??"").CompareTo(_time) < 0
                             orderby m.start_time descending
                             select new { m.ticket_id, m.start_time, m.last_active_time }).Take(3);

                return Ok(new { result = strSuccess, data = _list.OrderBy(s => s.start_time) });
            }
            catch (Exception ex)
            {
                return Ok(new { result = strFail, data = ex.Message });
            }

        }

        [HttpPost]
        public IActionResult GetStatistics([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strError, details = strInvalidParameters });
            string userId = (p["userId"] ?? "").ToString();
            string entry = (p["entry"] ?? "").ToString();
            string companyCode = (p["companyCode"] ?? "").ToString();

            var _r = (from m in _sconnDB.SC_Tickets
                      where m.enduser_id == userId && m.entry == entry && m.status_id == 2
                      && m.company_code == companyCode
                      select m).AsEnumerable().Select(
                      o => new { 
                          start_time = DateTime.Parse(o.start_time ?? "", CultureInfo.CurrentCulture), 
                          last_time = DateTime.Parse(o.last_active_time ?? "", CultureInfo.CurrentCulture) 
                      }).ToList();
            return Ok(new
            {
                result = strSuccess,
                data = new { _r.Count, AverageTime = _r.Average(x => x.last_time.Subtract(x.start_time).Seconds) }
            });
        }

        [HttpPost]
        public IActionResult GetCannedFiles([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strError, details = strInvalidParameters });
            string companyName = (p["companyName"] ?? "").ToString();
            if (companyName == "") return Ok(new { result = strError, details = strInvalidParameters });

            var _r = (from m in _sconnDB.SCRM_CannedFiles
                      where m.CompanyName == companyName && m.Active == true
                      orderby m.FileName
                      select m).AsEnumerable().Select(o =>
                     new
                     {
                         o.FileName,
                         o.FilePath,
                         o.FileUrl,
                         CreateDateTime = (System.IO.File.GetCreationTime(o.FilePath ?? "")).ToString("s"),
                         ContentType = MimeTypes.GetMimeType(o.FileName ?? ""),
                     });
            return Ok(new { result = strSuccess, data = _r });
        }

        [HttpPost]
        public IActionResult GetCannedMsgs([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strError, details = strInvalidParameters });
            string companyName = (p["companyName"] ?? "").ToString();
            if (companyName == "") return Ok(new { result = strError, details = strInvalidParameters });

            var _r = (from m in _sconnDB.SCRM_CannedMsgs
                      where m.CompanyName == companyName && m.Active == true
                      orderby m.MsgID
                      select m.Message).ToList();

            return Ok(new { result = strSuccess, data = _r });
        }

        [HttpPost]
        public IActionResult GetFBComments([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strError, details = strInvalidParameters });
            long ticketId = Convert.ToInt64((p["ticketId"]??"0").ToString());
            if (ticketId == 0) return Ok(new { result = strError, details = strInvalidParameters });
            string aboveMsgId = Convert.ToString((p["aboveMsgId"]??"").ToString());
            string afterMsgId = Convert.ToString((p["afterMsgId"] ?? "").ToString());
            int number = Convert.ToInt32((p["number"]??"0").ToString());

            var baseUri = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            var _r = _sconnSPDB.get_fb_comment(ticketId, aboveMsgId, afterMsgId).ToList();
            _r = _r.Select(x =>
            {
                if (x.msg_object_path != null)
                    x.msg_object_path = x.msg_object_path.Replace(@"\", @"/").Replace($"//{hostAddress}/", $"{baseUri}/");
                return x;
            }).ToList();

            if (number == 0)
                return Ok(new { result = strSuccess, total = _r.Count, data = _r });
            else
                return Ok(new { result = strSuccess, total = _r.Count, data = _r.Take(number).OrderBy(x => x.sent_time) });

        }

        [HttpPost]
        public IActionResult GetUserFBComments([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strError, details = strInvalidParameters });
            string companyCode = (p["companyCode"]??"").ToString();
            if (companyCode == "") return Ok(new { result = strError, details = strInvalidParameters });
            string endUserId = (p["endUserId"] ?? "").ToString();
            if (endUserId == "") return Ok(new { result = strError, details = strInvalidParameters });

            var _r = (from m in _sconnDB.SC_Tickets
                      where m.entry == "fb_comment"
                      && m.enduser_id == endUserId && m.company_code == companyCode
                      orderby m.start_time
                      select m).ToList();

            return Ok(new
            {
                result = strSuccess,
                total = _r.Count,
                data = _r
            });
        }

        [HttpPost]
        public IActionResult GetFBReplyComments([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strError, details = strInvalidParameters });
            long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());
            if (ticketId == 0) return Ok(new { result = strError, details = strInvalidParameters });
            string CommentId = (p["CommentId"] ?? "").ToString();
            if (CommentId == "") return Ok(new { result = strError, details = strInvalidParameters });
            int number = Convert.ToInt32((p["number"] ?? "0").ToString());

            var baseUri = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            var _r = (from m in _sconnDB.SC_MsgHistories
                      where m.ticket_id == ticketId && m.sc_comment_id == CommentId
                      orderby m.sent_time
                      select m).Skip(1).ToList();
            _r = _r.Select(x =>
            {
                if (x.msg_object_path != null)
                    x.msg_object_path = x.msg_object_path.Replace(@"\", @"/").Replace($"//{hostAddress}/", $"{baseUri}/");
                return x;
            }).ToList();

            if (number == 0)
                return Ok(new { result = strSuccess, data = _r });
            else
                return Ok(new { result = strSuccess, data = _r.Take(number) });
        }

        [HttpPost]
        public IActionResult GetFormData([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strError, details = strInvalidParameters });
            long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());
            if (ticketId == 0) return Ok(new { result = strError, details = strInvalidParameters });
            var _start_time = (from m in _sconnDB.SC_Tickets
                               where m.ticket_id == ticketId
                               select m.start_time).SingleOrDefault();

            var _online = (from m in _sconnDB.SC_OnlineForms
                           where m.ticket_id == ticketId
                           select new { field_name = m.field_key, m.field_value }).ToList();

            var _offline = (from m in _sconnDB.SC_OfflineForms
                            where m.ticket_id == ticketId
                            orderby m.field_index
                            select new { m.field_name, m.field_value }).ToList();
            return Ok(new { result = strSuccess, data = new { start_time = _start_time, online = _online, offline = _offline } });
        }

        [HttpPost]
        public IActionResult GetWhatsapp([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strFail, details = strInvalidParameters });

            if (p["startDate"] == null) return Ok(new { result = strFail, details = strInvalidParameters });
            if (p["endDate"] == null) return Ok(new { result = strFail, details = strInvalidParameters });
            if (p["companyCode"] == null) return Ok(new { result = strFail, details = strInvalidParameters });

            DateTime? startDate = Convert.ToDateTime(p["startDate"]?.ToString());
            DateTime? endDate = (Convert.ToDateTime(p["endDate"]?.ToString()));
            endDate = endDate?.AddDays(1);
            string companyCode = (p["companyCode"]??"").ToString();
            string phoneNo = (p["phoneNo"]??"").ToString();

            string phoneNo1 = ""; string phoneNo2 = "";
            if (phoneNo != "")
            {
                phoneNo1 = (phoneNo.Length <= 8) ? "whatsapp:+852" + phoneNo : "whatsapp:+" + phoneNo;  //Twilio
                phoneNo2 = (phoneNo.Length <= 8) ? "852" + phoneNo : phoneNo;            //Emma
            }

            var data = (from t in _sconnDB.SC_Tickets
                        join m in _sconnDB.SC_MsgHistories on t.ticket_id equals m.ticket_id
                        where t.entry == "whatsapp" && t.company_code == companyCode
                        && (phoneNo1 == "" || t.enduser_id == phoneNo1 || phoneNo2 == "" || t.enduser_id == phoneNo2)
                        && DateTime.ParseExact(m.sent_time,"yyyy-MM-dd", CultureInfo.InvariantCulture) >= startDate
                        && DateTime.ParseExact(m.sent_time, "yyyy-MM-dd", CultureInfo.InvariantCulture) < endDate
                        select m).ToList();
            return Ok(new { result = strSuccess, data });
        }

        [HttpPost]
        public IActionResult GetAgentName([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strError, details = strInvalidParameters });
            int[]? agentIds = (p["agentIds"] == null) ? null : p["agentIds"]?.GetValue<int[]>();
            if (agentIds == null) return Ok(new { result = strError, details = strInvalidParameters });
            
            var _r = (from m in _wiseDB.AgentInfos
                      where agentIds.Contains(m.AgentID)
                      select new { m.AgentID, m.AgentName }).ToList();
            return Ok(new { result = strSuccess, data = _r });
        }

        [HttpPost]
        public IActionResult Login([FromBody] JsonObject data)
        {
            if (data == null) return Ok(new { result = strFail, details = "Invalid login." });

            int sellerId = Convert.ToInt32((data["SellerID"]??"0").ToString());
            string password = (data["Password"] ?? "").ToString();

            var _r = (from m in _wiseDB.AgentInfos
                      where m.AgentID == sellerId && (m.Password??"").Substring(0, 3000) == password
                      select new
                      {
                          ColId = 1,
                          m.AgentID,
                          m.AgentName,
                          m.LevelID,
                          SellerID = "" + m.AgentID + "",
                          Counter = 0,
                          ExpiryDate = "",
                          LastLoginDate = "",
                          Account_status = "Active",
                          Email = "",
                          RoleName = "ETS Supervisor",
                          Companies = "campaignCRM",
                          Categories = "FB-Post,Menu,Overdue-Reminder,Scheduled-Reminder,System-Tools",
                          Functions = "Admin-Transfer,Escalation-List,Incomplete-Cases,Escalation-List-Fn,Incomplete-Cases-Fn,Overdue-Reminder-Fn,Search-Case-Fn,Search-Case,Search-Customer",
                          config = new List<object> { new { P_Id = 1, P_Name = "RecordPerPage_Case", P_Value="5" },
                                new { P_Id = 2, P_Name = "RecordPerPage_Case_Log", P_Value="5" },
                                new { P_Id = 3, P_Name = "PhotoSize_MB", P_Value="5" },
                                new { P_Id = 4, P_Name = "PasswordChangeFrequency", P_Value="180" }
                           }

                      }).SingleOrDefault();

            if (_r == null)
                return Ok(new { result = strFail, details = "Invalid login." });

            return Ok(new { result = strSuccess, details = _r });
        }
    }
}
