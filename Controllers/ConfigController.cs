using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WisePBX.NET8.Models.Wise;
using System.Text.Json.Nodes;
using System.Linq;
using WisePBX.NET8.Models.Wise_SP;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConfigController(WiseEntities _wisedb, WiseSPEntities _wiseSPdb) 
        : ControllerBase
    {
        [HttpPost]
        public IActionResult GetServiceList()
        {
            try
            {
                var _serviceIds = (from s in _wisedb.Service_ACDGroups select s.ServiceID).AsEnumerable();

                var data = (from i in _wisedb.Services
                            where _serviceIds.Contains(i.ServiceID)
                            orderby i.ServiceID
                            select new
                            {
                                i.ServiceID,
                                i.ServiceDesc
                            }).ToList();
                return Ok(new { result = WiseResult.Success, data, function = "GetServiceList" });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "GetServiceList" });
            }
        }

        [HttpPost]
        public IActionResult GetACDGroupList([FromBody] JsonObject p)
        {
            try
            {
                int serviceId = Convert.ToInt32((p["serviceId"]??"-1").ToString());
                var data = (from s in _wisedb.Services
                            join ag in _wisedb.Service_ACDGroups on s.ServiceID equals ag.ServiceID
                            join g in _wisedb.ACDGroups on ag.ACDGroupID equals g.AcdGroupID
                            where (serviceId == -1 || s.ServiceID == serviceId)
                            orderby g.AcdGroupID
                            select new
                            {
                                g.AcdGroupID,
                                g.AcdGroupDesc,
                                ag.ACDGroupType
                            }).ToList();

                if (serviceId == -1)
                    data = data.GroupBy(e => e.AcdGroupID).Select(g => g.First()).ToList(); // Distinct ACD Group

                return Ok(new { result = WiseResult.Success, data, function = "GetACDGroupList" });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "GetACDGroupList" });
            }
        }

        [HttpPost]
        public IActionResult GetAgentList([FromBody] JsonObject p)
        {
            try
            {
                int agentId = (p == null) ? -1 : Convert.ToInt32((p["agentId"]??"-1").ToString());

                var data = (from i in _wisedb.AgentInfos
                            where (agentId == -1 || i.AgentID == agentId)
                            orderby i.AgentID
                            select new
                            {
                                i.AgentID,
                                i.AgentName
                            }).ToList();
                return Ok(new { result = WiseResult.Success, data, function = "GetAgentList" });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "GetAgentList" });
            }
        }

        [HttpPost]
        public IActionResult GetSupervisorList([FromBody] JsonObject p)
        {
            try
            {
                if (p == null || p["agentIds"] == null) 
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function= "GetSupervisorList" });
                
                List<int>? agentIds = p["agentIds"]?.GetValue<List<int>>() ?? [];
                
                var data = (from i in _wisedb.AgentInfos
                            where agentIds.Contains(i.AgentID)
                            && (i.LevelID == 3 || i.LevelID == 4)
                            orderby i.AgentID
                            select new
                            {
                                i.AgentID,
                                i.AgentName,
                                i.LevelID
                            }).ToList();
                return Ok(new { result = WiseResult.Success, data, function = "GetSupervisorList" });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "GetSupervisorList" });
            }
        }

        [HttpPost]
        public IActionResult GetAgentInfo([FromBody] JsonObject p)
        {
            try
            {
                int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
                if (agentId == -1) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = "GetAgentInfo" });

                var info = (from i in _wisedb.AgentInfos
                            where i.AgentID == agentId
                            select i
                            ).SingleOrDefault();
                var acdGroups = (from g in _wisedb.ACDGroupMembers
                                 where g.AgentID == agentId
                                 orderby g.ACDGroupID
                                 select g.ACDGroupID).ToList();
                return Ok(new { result = WiseResult.Success, data = new { info, acdGroups }, function = "GetAgentInfo" });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "GetAgentInfo" });
            }
        }
        [HttpPost]
        public IActionResult GetMonitorStatistics([FromBody] JsonObject p)
        {
            try
            {
                int serviceId = Convert.ToInt32((p["serviceId"]??"-1").ToString());
                int groupId = Convert.ToInt32((p["groupId"] ?? "-1").ToString());

                if (serviceId == -1 || groupId == -1) 
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function= "GetMonitorStatistics" });

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
                                        (int)Math.Round((double)g.Sum(x => x.AnsweredCall??0) / (double)g.Sum(x => x.IncomingCall??0) * 100),
                                   PctAbandonedCall = (g.Sum(x => x.IncomingCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AbandonedCall ?? 0) / (double)g.Sum(x => x.IncomingCall ?? 0) * 100),
                                   AvgAbandonedTime = (g.Sum(x => x.AbandonedCall) == 0) ? 0 :
                                        (int)Math.Round((double)g.Sum(x => x.AbandonedTime ?? 0) / (double)g.Sum(x => x.AbandonedCall ?? 0)),
                                   AvgTalkTime = (g.Sum(x => x.AnsweredCall) + g.Sum(x => x.OutboundCall) == 0) ? 0 :
                                        (int)Math.Round((double)(g.Sum(x => x.AnsweredTalkTime ?? 0) + g.Sum(x => x.OutboundTalkTime ?? 0)) / (double)(g.Sum(x => x.AnsweredCall??0) + g.Sum(x => x.OutboundCall??0))),
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
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "GetMonitorStatistics" });
            }
        }

        [HttpPost]
        public IActionResult GetACDGroupAccessList([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = "GetACDGroupAccessList" });
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            
            try
            {
                if (p["agentId"] == null)
                {
                    var _list = (from a in _wisedb.ACDGroups orderby a.AcdGroupID select a).ToList();
                    return Ok(new { result = WiseResult.Success, data = _list });
                }
                else
                {
                    bool isAgent = (from a in _wisedb.AgentInfos where a.AgentID == agentId select a).Any();
                    if (!isAgent) return Ok(new { result = WiseResult.Fail, details = "No such agent." });

                    var data = (from a in _wisedb.ACDGroups
                                join g in _wisedb.ACDGroup_Accesses on a.AcdGroupID equals g.AcdGroupID into ps
                                from g in ps.Where(g => g.AgentID == agentId).DefaultIfEmpty()
                                orderby a.AcdGroupID
                                select new
                                {
                                    a.AcdGroupID,
                                    a.AcdGroupDesc,
                                    Accessible = g != null ,
                                }).ToList();

                    return Ok(new { result = WiseResult.Success, data, function = "GetACDGroupAccessList" });
                }
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "GetACDGroupAccessList" });
            }
        }

        [HttpPost]
        public IActionResult UpdateACDGroupAccessList([FromBody] JsonObject p)
        {
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            if (agentId == -1 || p["setting"] == null) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function= "UpdateACDGroupAccessList" });
            
            try
            {

                bool isAgent = (from a in _wisedb.AgentInfos where a.AgentID == agentId select a).Any();
                if (!isAgent) return Ok(new { result = WiseResult.Fail, details = "No such agent." });

                List<AcdGroupAccessClass> setting = p["setting"]?.GetValue<List<AcdGroupAccessClass>>() ?? [];

                foreach (AcdGroupAccessClass i in setting)
                {
                    var _info = (from a in _wisedb.ACDGroup_Accesses
                                 join g in _wisedb.ACDGroups on a.AcdGroupID equals g.AcdGroupID
                                 where a.AcdGroupID == i.groupId && a.AgentID == agentId
                                 select a).SingleOrDefault();

                    if (i.accessible && _info == null)
                    {
                        _wisedb.ACDGroup_Accesses.Add(new ACDGroup_Access
                        {
                            AcdGroupID = i.groupId,
                            AgentID = agentId
                        });


                    }
                    if (!i.accessible && _info != null)
                    {
                        _wisedb.ACDGroup_Accesses.Remove(_info);

                    }
                }
                _wisedb.SaveChanges();
                var data = (from a in _wisedb.ACDGroups
                            join g in _wisedb.ACDGroup_Accesses on a.AcdGroupID equals g.AcdGroupID into ps
                            from g in ps.Where(g => g.AgentID == agentId).DefaultIfEmpty()
                            orderby a.AcdGroupID
                            select new
                            {
                                a.AcdGroupID,
                                a.AcdGroupDesc,
                                Accessible = g != null,
                            }).ToList();
                return Ok(new { result = WiseResult.Success, data, function = "UpdateACDGroupAccessList" });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "UpdateACDGroupAccessList" });
            }
        }

        [HttpPost]
        public IActionResult AddACDGroupAccess([FromBody] JsonObject p)
        {
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int groupId = Convert.ToInt32((p["groupId"] ?? "-1").ToString());
            if (agentId == -1 || groupId == -1) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = "AddACDGroupAccess" });
            
            try
            {
                bool isAgent = (from a in _wisedb.AgentInfos where a.AgentID == agentId select a).Any();
                if (!isAgent) return Ok(new { result = WiseResult.Fail, details = "No such agent." });

                bool isGroup = (from a in _wisedb.ACDGroupMembers where a.ACDGroupID == groupId select a).Any();
                if (!isGroup) return Ok(new { result = WiseResult.Fail, details = "No such ACD Group." });

                var data = (from a in _wisedb.ACDGroup_Accesses
                            where a.AgentID == agentId && a.AcdGroupID == groupId
                            select a).SingleOrDefault();
                if (data != null) return Ok(new { result = WiseResult.Success });

                _wisedb.ACDGroup_Accesses.Add(new ACDGroup_Access
                {
                    AcdGroupID = groupId,
                    AgentID = agentId
                });
                _wisedb.SaveChanges();
                return Ok(new { result = WiseResult.Success, function = "AddACDGroupAccess" });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "AddACDGroupAccess" });
            }
        }

        [HttpPost]
        public IActionResult DelACDGroupAccess([FromBody] JsonObject p)
        {
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int groupId = Convert.ToInt32((p["groupId"] ?? "-1").ToString());

            if (agentId == -1 || groupId == -1) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = "DelACDGroupAccess" });
            try
            {
                bool isAgent = (from a in _wisedb.AgentInfos where a.AgentID == agentId select a).Any();
                if (!isAgent) return Ok(new { result = WiseResult.Fail, details = "No such agent." });

                bool isGroup = (from a in _wisedb.ACDGroupMembers where a.ACDGroupID == groupId select a).Any();
                if (!isGroup) return Ok(new { result = WiseResult.Fail, details = "No such ACD Group." });

                var data = (from a in _wisedb.ACDGroup_Accesses
                            where a.AgentID == agentId && a.AcdGroupID == groupId
                            select a).SingleOrDefault();
                if (data == null) return Ok(new { result = WiseResult.Success, function = "DelACDGroupAccess" });

                _wisedb.ACDGroup_Accesses.Remove(data);
                _wisedb.SaveChanges();
                return Ok(new { result = WiseResult.Success });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = "DelACDGroupAccess" });
            }
        }

        [HttpPost]
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
                return Ok(new { result = WiseResult.Fail, data = e.Message });
            }
        }
        [HttpPost]
        public IActionResult GetDashboardData_Agent([FromBody] JsonObject p)
        {
            try
            {
                int daysBefore = Convert.ToInt32((p["daysBefore"]??"-1").ToString());
                if (daysBefore == -1) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });

                var data = _wiseSPdb.SP_Dashboard_Data_Agent(daysBefore).ToList();
                return Ok(new { result = WiseResult.Success, data });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message });
            }
        }

        [HttpPost]
        public IActionResult GetWallboardCount([FromBody] JsonObject p)
        {
            try
            {
                if (p["reportDate"] == null) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
                DateTime reportDate = Convert.ToDateTime(p["reportDate"]?.ToString());


                var data = _wiseSPdb.SP_wallboard_count(reportDate);
                return Ok(new { result = WiseResult.Success, data });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message });
            }
        }
    }
}

