using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WisePBX.NET8.Models.Wise;
//using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
    
    
    public class CallController : _MediaController
    {
        private readonly IConfiguration configuration;
        private string hostDrive;
        private string hostName;
        private string hostAddress;

        public CallController(IConfiguration iConfig)
        {
            configuration = iConfig;
            hostDrive = configuration.GetValue<string>("hostDrive") ?? "";
            hostName = configuration.GetValue<string>("HostName") ?? "";
            hostAddress = configuration.GetValue<string>("HostAddress") ?? "";
        }

        [HttpPost]
        public IActionResult GetContent([FromBody] JsonObject p)
        {
            //int? id = (p["id"] == null) ? 0 : Convert.ToInt32(p["id"]?.GetValue<string>());
            int id = Convert.ToInt32((p["id"]??"0").ToString());
            if (id == 0) return Ok(new { result = "fail", details = "Invalid Parameters." });
            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

            WiseEntities _wisedb = new WiseEntities();
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
                            DNIS = c.DNIS,
                            ANI = c.ANI,
                            TalkTime = c.Talktime
                        }).ToList().Select(x => new 
                        {
                            FileName = x.FileName.Substring(x.FileName.LastIndexOf('\\') + 1),
                            FileUrl = x.FileUrl,
                            TimeStamp = x.TimeStamp,
                            CallerDisplay = (x.CallType == 1) ? x.DNIS : x.ANI,
                            TalkTime = x.TalkTime
                        });
            if (data.Count() == 0) return Ok(new { result = "fail", details = "No such record" });
            return Ok(new { result = "success", data });
        }
        //
        [HttpPost]
        public IActionResult GetVoiceMail([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });

            if (p["startDate"] == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
            if (p["endDate"] == null) return Ok(new { result = "fail", details = "Invalid Parameters." });

            DateTime startDate = Convert.ToDateTime(p["startDate"].ToString());
            DateTime endDate = Convert.ToDateTime(p["endDate"].ToString()).AddDays(1);
            
            int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
            string phoneNo = (p["phoneNo"]??"").ToString();
            string dnis = (p["dnis"] ?? "").ToString();
            string ani = (p["ani"] ?? "").ToString();
            int read = Convert.ToInt32((p["read"] ?? "-1").ToString());

            string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";
            WiseEntities _wisedb = new WiseEntities();
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
                        }).ToList().Take(1000);
            if (data.Count() == 0) return Ok(new { result = "fail", details = "No such record" });
            return Ok(new { result = "success", data });
        }

        [HttpPost]
        public IActionResult GetVoiceLog([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });

                if (p["startDate"] == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
                if (p["endDate"] == null) return Ok(new { result = "fail", details = "Invalid Parameters." });


                DateTime startDate = Convert.ToDateTime(p["startDate"].ToString());
                DateTime endDate = Convert.ToDateTime(p["endDate"].ToString()).AddDays(1);

                int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
                string phoneNo = (p["phoneNo"]??"").ToString();
                
                if (phoneNo != "" && phoneNo.Length < 8) return Ok(new { result = "fail", details = "Invalid Parameters." });

                string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

                WiseEntities _wisedb = new WiseEntities();
                //VoiceContentClass a;
                dynamic? data = null;
                if (agentId == -1)
                {
                    data = (from c in _wisedb.Calls
                            join v in _wisedb.Voicelogs on c.CallID equals v.CallID
                            where (c.Calltype >= 1 && c.Calltype <= 5)
                            && v.Time_stamp >= startDate && v.Time_stamp < endDate
                            && (phoneNo == "" || c.ANI == phoneNo || c.ANI == phoneNo)
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
                            }).ToList().Select(x => new 
                            {
                                CallId = x.CallID,
                                CallType = x.bOutbound + x.bInbound + x.bConference + x.bTransfer + x.bInterComm,
                                FilePath = x.FilePath,
                                FileName = x.FilePath.Substring(x.FilePath.LastIndexOf('\\') + 1),
                                FileUrl = x.FileUrl,
                                TimeStamp = x.TimeStamp,
                                PhoneNo = (x.bInterComm != "") ? "" : ((x.bOutbound != "") ? x.DNIS : x.ANI),
                                StaffNo = x.dStaffNo + ((x.dStaffNo != "" && x.oStaffNo != "") ? "," : "") + x.oStaffNo,
                                Duration = x.Duration,

                            }).ToList();
                }
                else
                {
                    data = (from c in _wisedb.Calls
                            join m in _wisedb.CallMemGrps on new { c.Calltype, c.CallID, DeviceType = 3, DeviceID = agentId } equals new { Calltype = 5, m.CallID, m.DeviceType, m.DeviceID }
                            into gg
                            from m in gg.DefaultIfEmpty()
                            join v in _wisedb.Voicelogs on c.CallID equals v.CallID
                            where ((c.Calltype >= 1 && c.Calltype <= 4) || (c.Calltype == 5 && m != null))
                            && v.Time_stamp >= startDate && v.Time_stamp < endDate
                            && ((c.dDeviceType == 3 && c.dDeviceID == agentId) || (c.oDeviceType == 3 && c.oDeviceID == agentId))
                            && (phoneNo == "" || c.ANI == phoneNo || c.DNIS == phoneNo)
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
                                bOutbound = (c.Calltype == 1) ? "Outbound" : "",
                                bInbound = (c.Calltype == 2 || (c.Calltype == 4 && c.dDeviceType == 3)) ? "Inbound" : "",
                                bConference = (c.Calltype == 5) ? "Conference" : "",
                                bTransfer = (c.Calltype == 4 && c.dDeviceType != 3) ? "Transfer" : "",
                                bInterComm = (c.Calltype == 3) ? "InterComm" : "",
                                dStaffNo = (c.dDeviceType == 3) ? c.dDeviceID.ToString() : "",
                                oStaffNo = (c.oDeviceType == 3) ? c.oDeviceID.ToString() : "",
                            }).ToList().Select(x => new 
                            {
                                CallId = x.CallID,
                                CallType = x.bOutbound + x.bInbound + x.bConference + x.bTransfer + x.bInterComm,
                                FilePath = x.FilePath,
                                FileName = x.FilePath.Substring(x.FilePath.LastIndexOf('\\') + 1),
                                FileUrl = x.FileUrl,
                                TimeStamp = x.TimeStamp,
                                PhoneNo = (x.bInterComm != "") ? "" : ((x.bOutbound != "") ? x.DNIS : x.ANI),
                                StaffNo = x.dStaffNo + ((x.dStaffNo != "" && x.oStaffNo != "") ? "," : "") + x.oStaffNo,
                                Duration = x.Duration,

                            }).ToList();
                }
                if (data.Count() == 0) return Ok(new { result = "fail", details = "No such record" });
                return Ok(new { result = "success", data });
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                return Ok(new { result = "fail", data = e.Message });
            }

        }
        [HttpPost]
        public IActionResult GetVoiceLogEx([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });

                //if (p.startDate == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
                //if (p.endDate == null) return Ok(new { result = "fail", details = "Invalid Parameters." });

                DateTime startDate = (p["startDate"] == null) ? DateTime.Today.AddYears(-1) : Convert.ToDateTime(p["startDate"].ToString());
                DateTime endDate = (p["endDate"] == null) ? DateTime.Today.AddDays(1) : (Convert.ToDateTime(p["endDate"].ToString())).AddDays(1);
                int serviceId = (p["serviceId"] == null) ? -1 : Convert.ToInt32((p["serviceId"]??"-1").ToString());
                //string agentId = (p.agentId == null) ? "" : "|" + Convert.ToString(p.agentId.Value) + "|";

                string[] agentId = (p["agentId"] == null) ? new string[] { } : 
                    (p["agentId"].GetType().Name == "JArray") ? p["agentId"].GetValue<string[]>() : 
                    new string[] { (p["agentId"] ?? "-1").ToString() };
                agentId = agentId.Select(m => "|" + m + "|").ToArray();

                string phoneNo = (p["phoneNo"] ?? "").ToString();
                int callType = Convert.ToInt32((p["callType"] ?? "-1").ToString());
                string ani = (p["ani"] ?? "").ToString();
                string dnis = (p["dnis"] ?? "").ToString();
                int[] callId = (p["callId"] == null) ? new int[] { } :
                    (p["callId"].GetType().Name == "JArray") ? p["callId"].GetValue<int[]>() :
                    new int[] { (int)p["callId"].GetValue<int>() };

                if (phoneNo != "" && phoneNo.Length < 8) return Ok(new { result = "fail", details = "Invalid Parameters." });

                string webUrl = $"{Request.Scheme}://{Request.Host.Value.TrimEnd(':')}{Request.PathBase}";

                WiseEntities _wisedb = new WiseEntities();


                //if (agentId == -1)

                var r = (from v in _wisedb.VW_FullVoiceLogs
                         join s in _wisedb.Services on v.ServiceID equals s.ServiceID
                         into ps
                         from o in ps.DefaultIfEmpty()
                         where (v.CallType >= 1 && v.CallType <= 5)
                         && (v.Begintime >= startDate)
                         && (v.Begintime < endDate)
                         && (serviceId == -1 || v.ServiceID == serviceId || (v.ServiceID == 0 && v.CallType == 3))
                         && (callType == -1 || v.CallType == callType)
                         && (phoneNo == "" || (v.PhoneNo??"").Contains(phoneNo))
                         //&& (agentId == "" || v.AgentList.Contains(agentId))
                         && (!agentId.Any() || agentId.Any(a => (v.AgentList??"").Contains(a)))
                         && (ani == "" || v.ANI == ani)
                         && (dnis == "" || v.DNIS == dnis)
                         && (!callId.Any() || callId.Contains(v.CallID))
                         orderby v.Begintime descending

                         select new
                         {
                             CallId = v.CallID,
                             ServiceName = o.ServiceDesc,
                             TimeStamp = v.Begintime,
                             CallType = v.CallTypeEx,
                             PhoneNo = v.PhoneNo,
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
                            FileName = ar.Substring(ar.LastIndexOf('\\') + 1),
                        };
                        x.VoiceFiles.Add(_voiceFile);
                    });
                });

                if (data.Count() == 0) return Ok(new { result = "fail", details = "No such record" });
                return Ok(new { result = "success", data });
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                return Ok(new { result = "fail", data = e.Message });
            }

        }

        [HttpPost]
        public IActionResult GetAgentList([FromBody] JsonObject p)
        {
            try
            {
                WiseEntities _wisedb = new WiseEntities();
                var data = (from i in _wisedb.AgentInfos
                            orderby i.AgentID
                            select new
                            {
                                i.AgentID,
                                i.AgentName
                            }).ToList();
                return Ok(new { result = "success", data });
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                return Ok(new { result = "fail", data = e.Message });
            }
        }



        [HttpPost]
        public IActionResult GetAgentInfo([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
                int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
                if (agentId == -1) return Ok(new { result = "fail", details = "Invalid Parameters." });

                WiseEntities _wisedb = new WiseEntities();
                var info = (from i in _wisedb.AgentInfos
                            where i.AgentID == agentId
                            select i
                            ).SingleOrDefault();
                var acdGroups = (from g in _wisedb.ACDGroupMembers
                                 where g.AgentID == agentId
                                 orderby g.ACDGroupID
                                 select g.ACDGroupID).ToList();
                return Ok(new { result = "success", data = new { info, acdGroups } });
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                return Ok(new { result = "fail", data = e.Message });
            }
        }

        [HttpPost]
        public IActionResult GetOutboundANI([FromBody] JsonObject p)
        {
            try
            {
                if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
                string serviceName = (p["serviceName"]??"").ToString();

                if (serviceName == "")
                    return Ok(new { result = "fail", details = "Invalid Parameters." });

                WiseEntities _wisedb = new WiseEntities();
                var data = (from i in _wisedb.OutboundANIs
                            where i.ServiceName == serviceName &&
                            i.OutboundType == "call"
                            select i.ANI).SingleOrDefault();
                if (data == null)
                    return Ok(new { result = "fail", details = "No such record." });
                return Ok(new { result = "success", data });
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                return Ok(new { result = "fail", data = e.Message });
            }
        }

        /*
        [HttpPost]
        public IActionResult GetRelativeCallID([FromBody] dynamic p)
        {
            try
            {
                if (p == null) return Ok(new { result = "fail", details = "Invalid Parameters." });
                if (p.callId == null) return Ok(new { result = "fail", details = "Invalid Parameters." });

                int callId = Convert.ToInt32(p.callId.Value);

                WiseEntities _wisedb = new WiseEntities();
                
                var data = (from i in _wisedb.FN_GetRelativeCallID(callId)
                            select i).ToList();
                return Ok(new { result = "success", data });
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                return Ok(new { result = "fail", data = e.Message });
            }
        }
        */
    }
}
