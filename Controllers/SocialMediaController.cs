using Microsoft.AspNetCore.Http;
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
    [Route(template:"api")]
    [ApiController]
    public class SocialMediaController (SConnectorEntities sEntities) : ControllerBase
    {
        private readonly SConnectorEntities _sconnDB= sEntities;

        [HttpPost]
        [Route(template: "SocialMedia/GetPreviousTicketId")]
        public IActionResult GetPreviousTicketId([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
                string userId = (p["userId"] ?? "").ToString();
                string entry = (p["entry"] ?? "").ToString();
                string companyCode = (p["companyCode"] ?? "").ToString();
                long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());

                string? _time = (from m in _sconnDB.SC_Tickets
                                 where m.enduser_id == userId && m.entry == entry
                                 && m.ticket_id == ticketId && m.company_code == companyCode
                                 select m.start_time).SingleOrDefault();
                if (_time == null) return Ok(new { result = WiseResult.Error, details = "Invalid Ticket No." });

                var _list = (from m in _sconnDB.SC_Tickets
                             where m.enduser_id == userId && m.entry == entry
                             && (m.start_time??"").CompareTo(_time) < 0
                             orderby m.start_time descending
                             select new { m.ticket_id, m.start_time, m.last_active_time }).Take(3);

                return Ok(new { result = WiseResult.Success, data = _list.OrderBy(s => s.start_time) });
            }
            catch (Exception ex)
            {
                return Ok(new { result = WiseResult.Fail, data = ex.Message });
            }

        }

        [HttpPost]
        [Route(template: "SocialMedia/GetCannedFiles")]
        public IActionResult GetCannedFiles([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
            string companyName = (p["companyName"] ?? "").ToString();
            if (companyName == "") return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });

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
            return Ok(new { result = WiseResult.Success, data = _r });
        }

        [HttpPost]
        [Route(template: "SocialMedia/GetCannedMsgs")]
        public IActionResult GetCannedMsgs([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
            string companyName = (p["companyName"] ?? "").ToString();
            if (companyName == "") return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });

            var _r = (from m in _sconnDB.SCRM_CannedMsgs
                      where m.CompanyName == companyName && m.Active == true
                      orderby m.MsgID
                      select m.Message).ToList();

            return Ok(new { result = WiseResult.Success, data = _r });
        }



        [HttpPost]
        [Route(template: "SocialMedia/GetFormData")]
        public IActionResult GetFormData([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
            long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());
            if (ticketId == 0) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
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
            return Ok(new { result = WiseResult.Success, data = new { start_time = _start_time, online = _online, offline = _offline } });
        }

        [HttpPost]
        [Route(template: "SocialMedia/GetStatistics")]
        public IActionResult GetStatistics([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
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
                result = WiseResult.Success,
                data = new { _r.Count, AverageTime = _r.Average(x => x.last_time.Subtract(x.start_time).Seconds) }
            });
        }
    }
}
