using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
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
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration configuration;
        private readonly string hostAddress;
        private readonly string fileUploadPath;
        

        public SocialMediaController(IConfiguration iConfig, IWebHostEnvironment ienvironment)
        {
            environment = ienvironment;
            configuration = iConfig;
            hostAddress = configuration.GetValue<string>("HostAddress") ?? "";
            fileUploadPath = configuration.GetValue<string>("FileUploadPath") ?? "";
            if (fileUploadPath == "")
                fileUploadPath = environment.ContentRootPath + "/Uploads";
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
                    return Ok(new { result = "fail", details = "Invalid Parameters." });
                if (form.files.Count == 0)
                    return Ok(new { result = "fail", details = "No File Upload." });

                string _fillFolder = Path.Combine(fileUploadPath, "Uploads");
                string _dateFolder = DateTime.Today.ToString("yyyyMMdd");
                _fillFolder = Path.Combine(_fillFolder, _dateFolder);
                if (!Directory.Exists(_fillFolder)) Directory.CreateDirectory(_fillFolder);
                _fillFolder = Path.Combine(_fillFolder, ticketId);
                if (!Directory.Exists(_fillFolder)) Directory.CreateDirectory(_fillFolder);
                string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

                var data = new List<dynamic>();
                foreach (var _file in form.files)
                {
                    string _filePath = Path.Combine(_fillFolder, _file.FileName);
                    using (Stream fileStream = new FileStream(_filePath, FileMode.Create))
                    {
                        await _file.CopyToAsync(fileStream);
                    }
                    data.Add(new
                    {
                        CreateDateTime = ((DateTime)System.IO.File.GetCreationTime(_filePath)).ToString("s"),
                        ContentType = _file.ContentType,
                        FileName = _file.FileName,
                        FilePath = _filePath,
                        FileUrl = webUrl + "/Uploads/" + _dateFolder + "/" + ticketId + "/" + _file.FileName

                    });
                }
                return Ok(new { result = "success", data });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "fail", data = ex.Message });
            }

        }

        [HttpPost]
        public IActionResult GetPreviousTicketId([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
                string userId = (p["userId"] ?? "").ToString();
                string entry = (p["entry"] ?? "").ToString();
                string companyCode = (p["companyCode"] ?? "").ToString();
                long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());

                SConnectorEntities _sconnDB = new SConnectorEntities();
                string? _time = (from m in _sconnDB.SC_Tickets
                                 where m.enduser_id == userId && m.entry == entry
                                 && m.ticket_id == ticketId && m.company_code == companyCode
                                 select m.start_time).SingleOrDefault();
                if (_time == null) return Ok(new { result = "error", details = "Invalid Ticket No." });

                var _list = (from m in _sconnDB.SC_Tickets
                             where m.enduser_id == userId && m.entry == entry
                             && (m.start_time??"").CompareTo(_time) < 0
                             orderby m.start_time descending
                             select new { m.ticket_id, m.start_time, m.last_active_time }).Take(3);

                return Ok(new { result = "success", data = _list.OrderBy(s => s.start_time) });
            }
            catch (Exception ex)
            {
                return Ok(new { result = "fail", data = ex.Message });
            }

        }

        [HttpPost]
        public IActionResult GetStatistics([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            string userId = (p["userId"] ?? "").ToString();
            string entry = (p["entry"] ?? "").ToString();
            string companyCode = (p["companyCode"] ?? "").ToString();

            SConnectorEntities _sconnDB = new SConnectorEntities();
            var _r = (from m in _sconnDB.SC_Tickets
                      where m.enduser_id == userId && m.entry == entry && m.status_id == 2
                      && m.company_code == companyCode
                      select m).AsEnumerable().Select(
                      o => new { start_time = DateTime.Parse(o.start_time, CultureInfo.CurrentCulture), last_time = DateTime.Parse(o.last_active_time, CultureInfo.CurrentCulture) }).ToList();
            return Ok(new
            {
                result = "success",
                data = new { Count = _r.Count, AverageTime = _r.Average(x => x.last_time.Subtract(x.start_time).Seconds) }
            });
        }

        [HttpPost]
        public IActionResult GetCannedFiles([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            string companyName = (p["companyName"] ?? "").ToString();
            if (companyName == "") return Ok(new { result = "error", details = "Invalid Parameters." });

            SConnectorEntities _sconnDB = new SConnectorEntities();
            var _r = (from m in _sconnDB.SCRM_CannedFiles
                      where m.CompanyName == companyName && m.Active == true
                      orderby m.FileName
                      select m).AsEnumerable().Select(o =>
                     new
                     {
                         FileName = o.FileName,
                         FilePath = o.FilePath,
                         FileUrl = o.FileUrl,
                         CreateDateTime = ((DateTime)System.IO.File.GetCreationTime(o.FilePath)).ToString("s"),
                         ContentType = MimeTypes.GetMimeType(o.FileName??""),
                     });
            return Ok(new { result = "success", data = _r });
        }

        [HttpPost]
        public IActionResult GetCannedMsgs([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            string companyName = (p["companyName"] ?? "").ToString();
            if (companyName == "") return Ok(new { result = "error", details = "Invalid Parameters." });

            SConnectorEntities _sconnDB = new SConnectorEntities();
            var _r = (from m in _sconnDB.SCRM_CannedMsgs
                      where m.CompanyName == companyName && m.Active == true
                      orderby m.MsgID
                      select m.Message).ToList();

            return Ok(new { result = "success", data = _r });
        }

        [HttpPost]
        public IActionResult GetFBComments([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            long ticketId = Convert.ToInt64((p["ticketId"]??"0").ToString());
            if (ticketId == 0) return Ok(new { result = "error", details = "Invalid Parameters." });
            string aboveMsgId = Convert.ToString((p["aboveMsgId"]??"").ToString());
            string afterMsgId = Convert.ToString((p["afterMsgId"] ?? "").ToString());
            int number = Convert.ToInt32((p["number"]??"0").ToString());

            var baseUri = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            SConnectorSPEntities _sconnDB = new SConnectorSPEntities();
            var _r = _sconnDB.get_fb_comment(ticketId, aboveMsgId, afterMsgId).ToList();
            _r = _r.Select(x =>
            {
                if (x.msg_object_path != null)
                    x.msg_object_path = x.msg_object_path.Replace(@"\", @"/").Replace($"//{hostAddress}/", $"{baseUri}/");
                return x;
            }).ToList();

            if (number == 0)
                return Ok(new { result = "success", total = _r.Count, data = _r });
            else
                return Ok(new { result = "success", total = _r.Count, data = _r.Take(number).OrderBy(x => x.sent_time) });

        }

        [HttpPost]
        public IActionResult GetUserFBComments([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            string companyCode = (p["companyCode"]??"").ToString();
            if (companyCode == "") return Ok(new { result = "error", details = "Invalid Parameters." });
            string endUserId = (p["endUserId"] ?? "").ToString();
            if (endUserId == "") return Ok(new { result = "error", details = "Invalid Parameters." });

            SConnectorEntities _sconnDB = new SConnectorEntities();
            var _r = (from m in _sconnDB.SC_Tickets
                      where m.entry == "fb_comment"
                      && m.enduser_id == endUserId && m.company_code == companyCode
                      orderby m.start_time
                      select m).ToList();

            return Ok(new
            {
                result = "success",
                total = _r.Count,
                data = _r
            });
        }

        [HttpPost]
        public IActionResult GetFBReplyComments([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());
            if (ticketId == 0) return Ok(new { result = "error", details = "Invalid Parameters." });
            string CommentId = (p["CommentId"] ?? "").ToString();
            if (CommentId == "") return Ok(new { result = "error", details = "Invalid Parameters." });
            int number = Convert.ToInt32((p["number"] ?? "0").ToString());

            var baseUri = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            SConnectorEntities _sconnDB = new SConnectorEntities();
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
                return Ok(new { result = "success", data = _r });
            else
                return Ok(new { result = "success", data = _r.Take(number) });
        }

        [HttpPost]
        public IActionResult GetFormData([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());
            if (ticketId == 0) return Ok(new { result = "error", details = "Invalid Parameters." });
            SConnectorEntities _sconnDB = new SConnectorEntities();
            var _start_time = (from m in _sconnDB.SC_Tickets
                               where m.ticket_id == ticketId
                               select m.start_time).SingleOrDefault();

            var _online = (from m in _sconnDB.SC_OnlineForms
                           where m.ticket_id == ticketId
                           select new { field_name = m.field_key, field_value = m.field_value }).ToList();

            var _offline = (from m in _sconnDB.SC_OfflineForms
                            where m.ticket_id == ticketId
                            orderby m.field_index
                            select new { m.field_name, m.field_value }).ToList();
            return Ok(new { result = "success", data = new { start_time = _start_time, online = _online, offline = _offline } });
        }

        [HttpPost]
        public IActionResult GetWhatsapp([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });

            if (p["startDate"] == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
            if (p["endDate"] == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
            if (p["companyCode"] == null) return Ok(new { result = "fail", details = "Invalid Parameters." });

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

            SConnectorEntities _dbSonn = new SConnectorEntities();
            var data = (from t in _dbSonn.SC_Tickets
                        join m in _dbSonn.SC_MsgHistories on t.ticket_id equals m.ticket_id
                        where t.entry == "whatsapp" && t.company_code == companyCode
                        && (phoneNo1 == "" || t.enduser_id == phoneNo1 || phoneNo2 == "" || t.enduser_id == phoneNo2)
                        && DateTime.ParseExact(m.sent_time,"yyyy-MM-dd", CultureInfo.InvariantCulture) >= startDate
                        && DateTime.ParseExact(m.sent_time, "yyyy-MM-dd", CultureInfo.InvariantCulture) < endDate
                        select m).ToList();
            return Ok(new { result = "success", data });
        }

        [HttpPost]
        public IActionResult GetAgentName([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            int[]? agentIds = (p["agentIds"] == null) ? null : p["agentIds"]?.GetValue<int[]>();
            if (agentIds == null) return Ok(new { result = "error", details = "Invalid Parameters." });
            WiseEntities _wiseDB = new WiseEntities();

            var _r = (from m in _wiseDB.AgentInfos
                      where agentIds.Contains(m.AgentID)
                      select new { m.AgentID, m.AgentName }).ToList();
            return Ok(new { result = "success", data = _r });
        }

        [HttpPost]
        public IActionResult Login([FromBody] JsonObject data)
        {
            if (data == null) return Ok(new { result = "fail", details = "Invalid login." });

            int sellerId = Convert.ToInt32((data["SellerID"]??"0").ToString());
            string password = (data["Password"] ?? "").ToString();

            WiseEntities _wiseDB = new WiseEntities();

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
                          //                 config = new List<object> { new { a = 1, b = "g" }, new { a=2, b="f" }  }
                          config = new List<object> { new { P_Id = 1, P_Name = "RecordPerPage_Case", P_Value="5" },
                                new { P_Id = 2, P_Name = "RecordPerPage_Case_Log", P_Value="5" },
                                new { P_Id = 3, P_Name = "PhotoSize_MB", P_Value="5" },
                                new { P_Id = 4, P_Name = "PasswordChangeFrequency", P_Value="180" }
                           }

                      }).SingleOrDefault();

            if (_r == null)
                return Ok(new { result = "fail", details = "Invalid login." });

            return Ok(new { result = "success", details = _r });
        }
    }
}
