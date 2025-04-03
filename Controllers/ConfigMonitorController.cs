using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.Wise;
using WisePBX.NET8.Models.Wise_SP;

namespace WisePBX.NET8.Controllers
{
    [Route(template:"api")]
    [ApiController]
    public class ConfigMonitorController(WiseEntities _wisedb, WiseSPEntities _wiseSPdb) : ControllerBase
    {
        [HttpPost]
        [Route(template: "Config/GetMonitorStatistics")]
        public IActionResult GetMonitorStatistics([FromBody] JsonObject p)
        {
            try
            {
                int serviceId = Convert.ToInt32((p["serviceId"] ?? "-1").ToString());
                int groupId = Convert.ToInt32((p["groupId"] ?? "-1").ToString());

                string? _grpType = (from a in _wisedb.Service_ACDGroups
                                    where a.ServiceID == serviceId &&
                                    a.ACDGroupID == groupId
                                    select a.ACDGroupType).SingleOrDefault();

                var service = (from s in _wisedb.Monitor_Statistics
                               where s.ServiceID == serviceId && s.ACDGroupType == _grpType
                               group s by s.ServiceID into g
                               select new
                               {
                                   TimeStamp = g.Min(x => x.TimeStamp),
                                   IncomingCall = g.Sum(x => x.IncomingCall),
                                   AnsweredCall = g.Sum(x => x.AnsweredCall),
                                   AbandonedCall = g.Sum(x => x.AbandonedCall),
                                   OutboundCall = g.Sum(x => x.OutboundCall),
                                   PctAnsweredCall = (g.Sum(x => x.IncomingCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AnsweredCall ?? 0) / (double)g.Sum(x => x.IncomingCall ?? 0) * 100),
                                   PctAbandonedCall = (g.Sum(x => x.IncomingCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AbandonedCall ?? 0) / (double)g.Sum(x => x.IncomingCall ?? 0) * 100),
                                   AvgAbandonedTime = (g.Sum(x => x.AbandonedCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AbandonedTime ?? 0) / (double)g.Sum(x => x.AbandonedCall ?? 0)),
                                   AvgTalkTime = (g.Sum(x => x.AnsweredCall) + g.Sum(x => x.OutboundCall) == 0) ? 0 :
                                        (int)Math.Round((double)(g.Sum(x => x.AnsweredTalkTime ?? 0) + g.Sum(x => x.OutboundTalkTime ?? 0)) / (double)(g.Sum(x => x.AnsweredCall ?? 0) + g.Sum(x => x.OutboundCall ?? 0))),
                                   AvgAnsweredTime = (g.Sum(x => x.AnsweredCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AnsweredWaitTime ?? 0) / (double)g.Sum(x => x.AnsweredCall ?? 0)),
                               }).SingleOrDefault();
                var acdGroup = (from s in _wisedb.Monitor_Statistics
                                where s.ServiceID == serviceId && s.ACDGroupID == groupId &&
                                s.ACDGroupType == _grpType
                                group s by s.ServiceID into g
                                select new
                                {
                                    IncomingCall = g.Sum(x => x.IncomingCall),
                                    AnsweredCall = g.Sum(x => x.AnsweredCall),
                                    AbandonedCall = g.Sum(x => x.AbandonedCall),
                                    PctAnsweredCall = (g.Sum(x => x.IncomingCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AnsweredCall ?? 0) / (double)g.Sum(x => x.IncomingCall ?? 0) * 100),
                                    PctAbandonedCall = (g.Sum(x => x.IncomingCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AbandonedCall ?? 0) / (double)g.Sum(x => x.IncomingCall ?? 0) * 100),
                                    AvgAbandonedTime = (g.Sum(x => x.AbandonedCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AbandonedTime ?? 0) / (double)g.Sum(x => x.AbandonedCall ?? 0)),
                                    AvgTalkTime = (g.Sum(x => x.AnsweredCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AnsweredTalkTime ?? 0) / (double)g.Sum(x => x.AnsweredCall ?? 0)),
                                    AvgAnsweredTime = (g.Sum(x => x.AnsweredCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AnsweredWaitTime ?? 0) / (double)g.Sum(x => x.AnsweredCall ?? 0)),
                                }).SingleOrDefault();
                return Ok(new { result = WiseResult.Success, data = new { service, acdGroup/*, TimeTicks = DateTime.MaxValue.Ticks */} });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetMonitorStatistics });
            }
        }
        [HttpPost]
        [Route(template: "Config/GetDashboardData")]
        public IActionResult GetDashboardData()
        {
            try
            {
                List<SP_Dashboard_Data_Result> data = _wiseSPdb.SP_Dashboard_Data().ToList();
                var inbound_call = data.Select(d => d.inbound_call);
                var inbound_vm = data.Select(d => d.inbound_vm);
                var inbound_email = data.Select(d => d.inbound_email);
                var inbound_fax = data.Select(d => d.inbound_fax);
                var inbound_webchat = data.Select(d => d.inbound_webchat);
                var inbound_wechat = data.Select(d => d.inbound_wechat);
                var inbound_fb_msg = data.Select(d => d.inbound_fb_msg);
                var inbound_whatsapp = data.Select(d => d.inbound_whatsapp);
                var outbound_call = data.Select(d => d.outbound_call);
                var outbound_sms = data.Select(d => d.outbound_sms);
                var outbound_email = data.Select(d => d.outbound_email);
                var outbound_fax = data.Select(d => d.outbound_fax);

                List<string[]> days30_list = data.Select(d => new string[2]
                {
                    d.time_stamp.DayOfWeek.ToString()[..1],
                    d.time_stamp.ToString("M/d")
                }).ToList();


                return Ok(new
                {
                    result = WiseResult.Success,
                    data = new
                    {
                        inbound_call,
                        inbound_vm,
                        inbound_email,
                        inbound_fax,
                        inbound_webchat,
                        inbound_wechat,
                        inbound_fb_msg,
                        inbound_whatsapp,
                        outbound_call,
                        outbound_sms,
                        outbound_email,
                        outbound_fax,
                        days30_list,
                    }
                });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetDashboardData });
            }
        }

        [HttpPost]
        [Route(template: "Config/GetDashboardData_Agent")]
        public IActionResult GetDashboardData_Agent([FromBody] JsonObject p)
        {
            try
            {
                int daysBefore = Convert.ToInt32((p["daysBefore"] ?? "-1").ToString());
                if (daysBefore == -1)
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Config.GetDashboardData_Agent });

                var data = _wiseSPdb.SP_Dashboard_Data_Agent(daysBefore).ToList();
                return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Config.GetDashboardData_Agent });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetDashboardData_Agent });
            }
        }

        [HttpPost]
        [Route(template: "Config/GetWallboardCount")]
        public IActionResult GetWallboardCount([FromBody] JsonObject p)
        {
            try
            {
                if (p["reportDate"] == null)
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Config.GetWallboardCount });
                DateTime reportDate = Convert.ToDateTime(p["reportDate"]?.ToString());


                var data = _wiseSPdb.SP_wallboard_count(reportDate);
                return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Config.GetWallboardCount });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetWallboardCount });
            }
        }
    }
}
