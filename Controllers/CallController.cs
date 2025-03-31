using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WisePBX.NET8.Models.Wise;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Runtime.CompilerServices;
using static Org.BouncyCastle.Math.EC.ECCurve;
namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
    
    public class CallController(IConfiguration iConfig, WiseEntities wiseEntities) 
        : _MediaController(wiseEntities)
    {
        private readonly string strSuccess = "success";
        private readonly string strFail = "fail";
        private readonly string strInvalidParameters = "Invalid Parameters.";
        private readonly string strNoSuchRecord = "No such record.";

        private readonly string hostDrive = iConfig.GetValue<string>("hostDrive") ?? "";
        private readonly string hostName = iConfig.GetValue<string>("HostName") ?? "";

        private readonly WiseEntities _wisedb = wiseEntities;
        
        [HttpPost]
        public IActionResult GetContent([FromBody] JsonObject p)
        {
            int id = Convert.ToInt32((p["id"]??"0").ToString());
            if (id == 0) return Ok(new { result = strFail, details = strInvalidParameters });
            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

            var data = (from c in _wisedb.Calls
                        join v in _wisedb.Voicelogs on c.CallID equals v.CallID
                        into ps
                        from v in ps.DefaultIfEmpty()
                        where c.CallID == id && (c.Calltype >= 1 && c.Calltype <= 5)
                        orderby v.SerialID
                        select new
                        {
                            FileName = v.Filepath,
                            FileUrl = v.Filepath.Replace(@"\", @"/").Replace("//" + hostName + "/", webUrl +"/"),
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
            if (!data.Any()) return Ok(new { result = strFail, details = strNoSuchRecord });
            return Ok(new { result = strSuccess, data });
        }
        
        [HttpPost]
        public IActionResult GetVoiceMail([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = strFail, details = strInvalidParameters });

            if (p["startDate"] == null) return Ok(new { result = strFail, details = strInvalidParameters });
            if (p["endDate"] == null) return Ok(new { result = strFail, details = strInvalidParameters });
            
            DateTime startDate = Convert.ToDateTime((p["startDate"]??"").ToString());
            DateTime endDate = Convert.ToDateTime((p["endDate"] ?? "").ToString()).AddDays(1);
            
            int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
            string phoneNo = (p["phoneNo"]??"").ToString();
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
                            FileUrl = (m.Filename??"").Replace(hostDrive + @":\", webUrl+"/").Replace(@"\", @"/"),
                            TimeStamp = m.ArriveDateTime,
                            Duration = m.MediaDuration ?? o.VMDuration ?? 0,
                            m.IvrsData,
                            m.ReadFlag,
                        }).AsEnumerable().Take(1000);
            if (!data.Any()) return Ok(new { result = strFail, details = strNoSuchRecord });
            return Ok(new { result = strSuccess, data });
        }

        [HttpPost]
        public IActionResult GetVoiceLog([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = strFail, details = strInvalidParameters });

                if (p["startDate"] == null) return Ok(new { result = strFail, details = strInvalidParameters });
                if (p["endDate"] == null) return Ok(new { result = strFail, details = strInvalidParameters });


                DateTime startDate = Convert.ToDateTime((p["startDate"] ?? "").ToString());
                DateTime endDate = Convert.ToDateTime((p["endDate"] ?? "").ToString()).AddDays(1);

                int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
                string phoneNo = (p["phoneNo"]??"").ToString();
                
                if (phoneNo != "" && phoneNo.Length < 8) return Ok(new { result = strFail, details = strInvalidParameters });

                string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

                var data = (from c in _wisedb.Calls
                        join v in _wisedb.Voicelogs on c.CallID equals v.CallID
                        where (c.Calltype >= 1 && c.Calltype <= 5)
                        && v.Time_stamp >= startDate && v.Time_stamp < endDate
                        && (phoneNo == "" || c.ANI == phoneNo || c.ANI == phoneNo)
                        && (agentId == -1 || ((c.dDeviceType == 3 && c.dDeviceID == agentId) || (c.oDeviceType == 3 && c.oDeviceID == agentId)))
                        orderby v.SerialID
                        select new
                        {
                            c.CallID,
                            FilePath = v.Filepath,
                            FileUrl = v.Filepath.Replace(@"\", @"/").Replace("//" + hostName + "/", webUrl + "/"),
                            TimeStamp = c.Begintime,
                            c.DNIS,
                            c.ANI,
                                
                            Duration = c.Talktime,
                            dStaffNo = (c.dDeviceType == 3) ? c.oDeviceID.ToString() : "",
                            oStaffNo = (c.oDeviceType == 3) ? c.oDeviceID.ToString() : "",
                            bOutbound = (c.Calltype == 1) ? "Outbound" : "",
                            bInbound = (c.Calltype == 2 || (c.Calltype == 4 && c.dDeviceType == 3)) ? "Inbound" : "",
                            bConference = (c.Calltype == 5) ? "Conference" : "",
                            bTransfer = (c.Calltype == 4 && c.dDeviceType != 3) ? "Transfer" : "",
                            bInterComm = (c.Calltype == 3) ? "InterComm" : "",
                            PhoneNo = (c.Calltype == 3)? "" : c.ANI,
                        }).AsEnumerable().Select(x => new 
                        {
                            CallId = x.CallID,
                            CallType = x.bOutbound + x.bInbound + x.bConference + x.bTransfer + x.bInterComm,
                            x.FilePath,
                            FileName = x.FilePath[(x.FilePath.LastIndexOf('\\') + 1)..],
                            x.FileUrl,
                            x.TimeStamp,
                            PhoneNo = x.bOutbound != ""? x.DNIS : x.PhoneNo ,
                            StaffNo = x.dStaffNo + ((x.dStaffNo != "" && x.oStaffNo != "") ? "," : "") + x.oStaffNo,
                            x.Duration,

                        }).ToList();
                
                
                if (data.Count == 0) return Ok(new { result = strFail, details = strNoSuchRecord });
                return Ok(new { result = strSuccess, data });
            }
            catch (Exception e)
            {
                return Ok(new { result = strFail, data = e.Message });
            }

        }
        [HttpPost]
        public IActionResult GetVoiceLogEx([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = strFail, details = strInvalidParameters });
                
                DateTime startDate = (p["startDate"] == null) ? DateTime.Today : Convert.ToDateTime(p["startDate"]?.ToString());
                DateTime endDate = (p["endDate"] == null) ? DateTime.Today.AddDays(1) : (Convert.ToDateTime(p["endDate"]?.ToString())).AddDays(1);
                int serviceId = (p["serviceId"] == null) ? -1 : Convert.ToInt32((p["serviceId"]??"-1").ToString());

                string[] agentId = []; 
                if (p["agentId"] != null)
                {
                    if (p!["agentId"]!.GetType().Name == "JArray")
                        agentId = (p!["agentId"]!).GetValue<string[]>();
                    else
                        agentId =  [p!["agentId"]!.ToString()];
                    
                }
                agentId = (agentId ??[]).Select(m => "|" + m + "|").ToArray();

                string phoneNo = (p["phoneNo"] ?? "").ToString();
                int callType = Convert.ToInt32((p["callType"] ?? "-1").ToString());
                string ani = (p["ani"] ?? "").ToString();
                string dnis = (p["dnis"] ?? "").ToString();
                int[]? callId = [];
                if (p["callId"] != null)
                {
                    if (p["callId"]?.GetType().Name == "JArray")
                        callId = p!["callId"]!.GetValue<int[]>();
                    else
                        callId = [p!["callId"]!.GetValue<int>()];
                }
                if (phoneNo != "" && phoneNo.Length < 8) return Ok(new { result = strFail, details = strInvalidParameters });

                string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

                var r = (from v in _wisedb.VW_FullVoiceLogs
                         join s in _wisedb.Services on v.ServiceID equals s.ServiceID
                         into ps
                         from o in ps.DefaultIfEmpty()
                         where (v.CallType >= 1 && v.CallType <= 5)
                         && (v.Begintime >= startDate) && (v.Begintime < endDate)
                         && (serviceId == -1 || v.ServiceID == serviceId || (v.ServiceID == 0 && v.CallType == 3))
                         && (callType == -1 || v.CallType == callType)
                         && (phoneNo == "" || (v.PhoneNo??"").Contains(phoneNo))
                         && (agentId.Length==0 || agentId.Any(a => (v.AgentList??"").Contains(a)))
                         && (ani == "" || v.ANI == ani)
                         && (dnis == "" || v.DNIS == dnis)
                         && (callId.Length == 0 || callId.Contains(v.CallID))
                         orderby v.Begintime descending

                         select new
                         {
                             CallId = v.CallID,
                             ServiceName = o.ServiceDesc,
                             TimeStamp = v.Begintime,
                             CallType = v.CallTypeEx,
                             v.PhoneNo,
                             Duration = v.Talktime,
                             StaffNo = (v.AgentList ?? "").Replace("|", ""),
                             FilePaths = v.Filepath,
                             VoiceFiles = new List<dynamic>()
                         });
                
                    
                var data = r.Take(1000).ToList();
                
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
                
                if (data.Count == 0) return Ok(new { result = strFail, details = strNoSuchRecord });
                return Ok(new { result = strSuccess, data });
            }
            catch (Exception e)
            {
                return Ok(new { result = strFail, data = e.Message });
            }

        }

        [HttpPost]
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
                return Ok(new { result = strSuccess, data });
            }
            catch (Exception e)
            {
                return Ok(new { result = strFail, data = e.Message });
            }
        }



        [HttpPost]
        public IActionResult GetAgentInfo([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = strFail, details = strInvalidParameters });
                int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
                if (agentId == -1) return Ok(new { result = strFail, details = strInvalidParameters });

                var info = (from i in _wisedb.AgentInfos
                            where i.AgentID == agentId
                            select i
                            ).SingleOrDefault();
                var acdGroups = (from g in _wisedb.ACDGroupMembers
                                 where g.AgentID == agentId
                                 orderby g.ACDGroupID
                                 select g.ACDGroupID).ToList();
                return Ok(new { result = strSuccess, data = new { info, acdGroups } });
            }
            catch (Exception e)
            {
                return Ok(new { result = strFail, data = e.Message });
            }
        }

        [HttpPost]
        public IActionResult GetOutboundANI([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = strFail, details = strInvalidParameters });
                string serviceName = (p["serviceName"]??"").ToString();

                if (serviceName == "")
                    return Ok(new { result = strFail, details = strInvalidParameters });

                var data = (from i in _wisedb.OutboundANIs
                            where i.ServiceName == serviceName &&
                            i.OutboundType == "call"
                            select i.ANI).SingleOrDefault();
                if (data == null)
                    return Ok(new { result = strFail, details = strNoSuchRecord });
                return Ok(new { result = strSuccess, data });
            }
            catch (Exception e)
            {
                return Ok(new { result = strFail, data = e.Message });
            }
        }
    }
}
