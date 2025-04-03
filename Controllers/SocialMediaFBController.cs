using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.SConnector;
using WisePBX.NET8.Models.SConnector_SP;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class SocialMediaFBController(IConfiguration iConfig,
            SConnectorEntities sEntities, SConnectorSPEntities sEntitiesSP) : ControllerBase
    {
        private readonly SConnectorEntities _sconnDB = sEntities;
        private readonly SConnectorSPEntities _sconnSPDB = sEntitiesSP;
        private readonly string hostAddress = iConfig.GetValue<string>("HostAddress") ?? "";

        [HttpPost]
        [Route(template: "SocialMedia/GetFBComments")]
        public IActionResult GetFBComments([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
            long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());
            if (ticketId == 0) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
            string aboveMsgId = Convert.ToString((p["aboveMsgId"] ?? "").ToString());
            string afterMsgId = Convert.ToString((p["afterMsgId"] ?? "").ToString());
            int number = Convert.ToInt32((p["number"] ?? "0").ToString());

            var baseUri = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            var _r = _sconnSPDB.get_fb_comment(ticketId, aboveMsgId, afterMsgId).ToList();
            _r = _r.Select(x =>
            {
                if (x.msg_object_path != null)
                    x.msg_object_path = x.msg_object_path.Replace(@"\", @"/").Replace($"//{hostAddress}/", $"{baseUri}/");
                return x;
            }).ToList();

            if (number == 0)
                return Ok(new { result = WiseResult.Success, total = _r.Count, data = _r });
            else
                return Ok(new { result = WiseResult.Success, total = _r.Count, data = _r.Take(number).OrderBy(x => x.sent_time) });

        }

        [HttpPost]
        [Route(template: "SocialMedia/GetUserFBComments")]
        public IActionResult GetUserFBComments([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
            string companyCode = (p["companyCode"] ?? "").ToString();
            if (companyCode == "") return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
            string endUserId = (p["endUserId"] ?? "").ToString();
            if (endUserId == "") return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });

            var _r = (from m in _sconnDB.SC_Tickets
                      where m.entry == "fb_comment"
                      && m.enduser_id == endUserId && m.company_code == companyCode
                      orderby m.start_time
                      select m).ToList();

            return Ok(new
            {
                result = WiseResult.Success,
                total = _r.Count,
                data = _r
            });
        }

        [HttpPost]
        [Route(template: "SocialMedia/GetFBReplyComments")]
        public IActionResult GetFBReplyComments([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
            long ticketId = Convert.ToInt64((p["ticketId"] ?? "0").ToString());
            if (ticketId == 0) return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
            string CommentId = (p["CommentId"] ?? "").ToString();
            if (CommentId == "") return Ok(new { result = WiseResult.Error, details = WiseError.InvalidParameters });
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
                return Ok(new { result = WiseResult.Success, data = _r });
            else
                return Ok(new { result = WiseResult.Success, data = _r.Take(number) });
        }

        [HttpPost]
        [Route(template: "SocialMedia/GetWhatsapp")]
        public IActionResult GetWhatsapp([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

            if (p["startDate"] == null) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
            if (p["endDate"] == null) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
            if (p["companyCode"] == null) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

            DateTime? startDate = Convert.ToDateTime(p["startDate"]?.ToString());
            DateTime? endDate = (Convert.ToDateTime(p["endDate"]?.ToString()));
            endDate = endDate?.AddDays(1);
            string companyCode = (p["companyCode"] ?? "").ToString();
            string phoneNo = (p["phoneNo"] ?? "").ToString();

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
                        && DateTime.ParseExact(m.sent_time, "yyyy-MM-dd", CultureInfo.InvariantCulture) >= startDate
                        && DateTime.ParseExact(m.sent_time, "yyyy-MM-dd", CultureInfo.InvariantCulture) < endDate
                        select m).ToList();
            return Ok(new { result = WiseResult.Success, data });
        }
        

    }
}
