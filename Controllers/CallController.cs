using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WisePBX.NET8.Models.Wise;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Runtime.CompilerServices;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.Ocsp;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Linq;
using Org.BouncyCastle.Asn1.X509;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace WisePBX.NET8.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class CallController(IConfiguration iConfig, WiseEntities wiseEntities)
        : WiseBaseController(wiseEntities)
    {
        private readonly string hostDrive = iConfig.GetValue<string>("hostDrive") ?? "";
        private readonly string hostName = iConfig.GetValue<string>("HostName") ?? "";

        private readonly WiseEntities _wisedb = wiseEntities;

        [HttpPost]
        [Route(template: "Call/GetContent")]
        public IActionResult GetContent([FromBody] JsonObject p)
        {
            int id = Convert.ToInt32((p["id"] ?? "0").ToString());
            if (id == 0) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

            var data = (from c in _wisedb.Calls
                        join v in _wisedb.Voicelogs on c.CallID equals v.CallID
                        into ps
                        from v in ps.DefaultIfEmpty()
                        where c.CallID == id && (c.Calltype >= 1 && c.Calltype <= 5)
                        orderby v.SerialID
                        select new
                        {
                            FileName = v.Filepath ?? "",
                            FileUrl = (v.Filepath ?? "").Replace(@"\", @"/").Replace("//" + hostName + "/", webUrl + "/"),
                            TimeStamp = c.Begintime,
                            CallType = c.Calltype,
                            c.DNIS,
                            c.ANI,
                            TalkTime = c.Talktime
                        }).AsEnumerable().Select(x => new
                        {
                            FileName = x.FileName[(x.FileName.LastIndexOf('\\') + 1)..],
                            x.FileUrl,
                            x.TimeStamp,
                            CallerDisplay = (x.CallType == 1) ? x.DNIS : x.ANI,
                            x.TalkTime
                        });
            if (!data.Any()) return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchRecord });
            return Ok(new { result = WiseResult.Success, data });
        }

        [HttpPost]
        [Route(template: "Call/GetVoiceMail")]
        public IActionResult GetVoiceMail([FromBody] JsonObject p)
        {
            DateTime startDate = Convert.ToDateTime((p["startDate"] ?? "").ToString());
            DateTime endDate = Convert.ToDateTime((p["endDate"] ?? "").ToString()).AddDays(1);

            int agentId = Convert.ToInt32((p[WiseParam.AgentId] ?? "-1").ToString());
            string phoneNo = (p["phoneNo"] ?? "").ToString();
            string dnis = (p["dnis"] ?? "").ToString();
            string ani = (p["ani"] ?? "").ToString();
            int read = Convert.ToInt32((p["read"] ?? "-1").ToString());

            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            var data = (from m in _wisedb.MediaCalls
                        join v in _wisedb.Voicemails on m.PrevCallID equals v.CallID
                        into ps
                        from o in ps.DefaultIfEmpty()
                        where m.CallType == 7 &&
                              (agentId == -1 || m.AgentID == agentId)
                              && (phoneNo == "" || m.ANI == phoneNo)
                              && (read == -1 || m.ReadFlag == read)
                              && (ani == "" || m.ANI == ani)
                              && (dnis == "" || m.DNIS == dnis)
                              && m.ArriveDateTime >= startDate
                              && m.ArriveDateTime <= endDate
                        orderby m.ArriveDateTime descending
                        select new
                        {
                            m.CallID,
                            m.Subject,
                            PhoneNo = m.ANI,
                            m.ANI,
                            m.DNIS,
                            StaffNo = m.AgentID,
                            FilePath = m.Filename,
                            FileUrl = (m.Filename ?? "").Replace(hostDrive + @":\", webUrl + "/").Replace(@"\", @"/"),
                            TimeStamp = m.ArriveDateTime,
                            Duration = m.MediaDuration ?? o.VMDuration ?? 0,
                            m.IvrsData,
                            m.ReadFlag,
                        }).AsEnumerable().Take(1000);
            if (!data.Any()) return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchRecord });
            return Ok(new { result = WiseResult.Success, data });
        }
        

        private static Expression<Func<VW_FullVoiceLog, bool>> VoicelogFilter(dynamic d)
        {
            DateTime startDate = d.startDate;
            DateTime endDate = d.endDate;
            int serviceId = d.serviceId;
            int callType = d.callType;
            string phoneNo = d.phoneNo;
            string[] agentId = d.agentId;
            string ani = d.ani;
            string dnis = d.dnis;
            int[] callId = d.callId;
            
            return v => (v.Begintime >= startDate) && (v.Begintime < endDate)
                         && (serviceId == -1 || v.ServiceID == serviceId || (v.ServiceID == 0 && v.CallType == 3))
                         && (callType == -1 || v.CallType == callType)
                         && (phoneNo == "" || (v.PhoneNo ?? "").Contains(phoneNo))
                         && (agentId.Length == 0 || agentId.Any(a => (v.AgentList ?? "").Contains(a)))
                         && (ani == "" || v.ANI == ani)
                         && (dnis == "" || v.DNIS == dnis)
                         && (callId.Length == 0 || callId.Contains(v.CallID));
        }

        [HttpPost]
        [Route(template: "Call/GetVoiceLogEx")]
        public IActionResult GetVoiceLogEx([FromBody] JsonObject p)
        {
            try
            {
                DateTime startDate = (p["startDate"] == null) ? DateTime.Today : Convert.ToDateTime(p["startDate"]?.ToString());
                DateTime endDate = (p["endDate"] == null) ? DateTime.Today.AddDays(1) : (Convert.ToDateTime(p["endDate"]?.ToString())).AddDays(1);
                int serviceId = (p["serviceId"] == null) ? -1 : Convert.ToInt32((p["serviceId"]??"-1").ToString());

                string[]? agentId;
                if (p![WiseParam.AgentId]!?.GetType().Name == "JsonArray")
                    agentId = JsonConvert.DeserializeObject<string[]>(p![WiseParam.AgentId]!.ToJsonString());
                else
                    agentId = (p[WiseParam.AgentId]==null)? []: [p![WiseParam.AgentId]!.ToString()];
                
                
                agentId = (agentId??[]).Select(m => "|" + m + "|").ToArray();

                string phoneNo = (p["phoneNo"] ?? "").ToString();
                int callType = Convert.ToInt32((p["callType"] ?? "-1").ToString());
                string ani = (p["ani"] ?? "").ToString();
                string dnis = (p["dnis"] ?? "").ToString();
                int[]? callId =[];
                if (p[WiseParam.CallId] != null)
                {
                    if (p[WiseParam.CallId]?.GetType().Name == "JsonArray")
                        callId = JsonConvert.DeserializeObject<int[]>(p![WiseParam.CallId]!.ToJsonString());
                    else
                        callId = [p![WiseParam.CallId]!.GetValue<int>()];
                }
                
                string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
                var data = _wisedb.VW_FullVoiceLogs.Where(VoicelogFilter(
                    new
                    {
                        startDate,
                        endDate,
                        serviceId,
                        callType,
                        phoneNo,
                        agentId,
                        callId,
                        ani,
                        dnis
                    })).Select(v=>new
                    {
                        CallId = v.CallID,
                        ServiceName = v.ServiceDesc,
                        TimeStamp = v.Begintime,
                        CallType = v.CallTypeEx,
                        v.PhoneNo,
                        Duration = v.Talktime,
                        StaffNo = (v.AgentList ?? "").Replace("|", ""),
                        FilePaths = v.Filepath??"",
                        VoiceFiles = new List<dynamic>()
                    }).ToList();

                data.ForEach(x => {
                    Array.ForEach(x.FilePaths.Split(','), ar => {
                        var _voiceFile = new
                        {
                            FilePath = ar,
                            FileUrl = ar.Replace(@"\", @"/").Replace("//" + hostName + "/", webUrl + "/"),
                            FileName = ar[(ar.LastIndexOf('\\') + 1)..],
                        };
                        x.VoiceFiles.Add(_voiceFile);
                    });
                });



                if (data.Count == 0) return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchRecord });
                return Ok(new { result = WiseResult.Success, data });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message });
            }

        }

        [HttpPost]
        [Route(template: "Call/GetAgentList")]
        public IActionResult GetAgentList()
        {
            try
            {
                var data = (from i in _wisedb.AgentInfos
                            orderby i.AgentID
                            select new
                            {
                                i.AgentID,
                                i.AgentName
                            }).ToList();
                return Ok(new { result = WiseResult.Success, data });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message });
            }
        }



        [HttpPost]
        [Route(template: "Call/GetAgentInfo")]
        public IActionResult GetAgentInfo([FromBody] JsonObject p)
        {
            try
            {
                int agentId = Convert.ToInt32((p[WiseParam.AgentId]??"-1").ToString());
                if (agentId == -1) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

                var info = (from i in _wisedb.AgentInfos
                            where i.AgentID == agentId
                            select i
                            ).SingleOrDefault();
                var acdGroups = (from g in _wisedb.ACDGroupMembers
                                 where g.AgentID == agentId
                                 orderby g.ACDGroupID
                                 select g.ACDGroupID).ToList();
                return Ok(new { result = WiseResult.Success, data = new { info, acdGroups } });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message });
            }
        }

        [HttpPost]
        [Route(template: "Call/GetOutboundANI")]
        public IActionResult GetOutboundANI([FromBody] JsonObject p)
        {
            try
            {
                string serviceName = (p["serviceName"]??"").ToString();

                if (serviceName == "")
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

                var data = (from i in _wisedb.OutboundANIs
                            where i.ServiceName == serviceName &&
                            i.OutboundType == "call"
                            select i.ANI).SingleOrDefault();
                if (data == null)
                    return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchRecord });
                return Ok(new { result = WiseResult.Success, data });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message });
            }
        }
    }
}
