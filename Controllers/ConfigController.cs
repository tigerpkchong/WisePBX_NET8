using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WisePBX.NET8.Models.Wise;
using System.Text.Json.Nodes;
using System.Linq;
using WisePBX.NET8.Models.Wise_SP;
using Newtonsoft.Json;

namespace WisePBX.NET8.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class ConfigController(WiseEntities _wisedb, WiseSPEntities _wiseSPdb) 
        : ControllerBase
    {
        [HttpPost]
        [Route(template: "Config/GetServiceList")]
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
                return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Config.GetServiceList });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetServiceList });
            }
        }

        [HttpPost]
        [Route(template: "Config/GetACDGroupList")]
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

                return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Config.GetACDGroupList });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetACDGroupList });
            }
        }

        [HttpPost]
        [Route(template: "Config/GetAgentList")]
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
                return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Config.GetAgentList });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetAgentList });
            }
        }

        [HttpPost]
        [Route(template: "Config/GetSupervisorList")]
        public IActionResult GetSupervisorList([FromBody] JsonObject p)
        {
            try
            {
                if (p == null || p["agentIds"] == null) 
                    return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Config.GetSupervisorList});
                
                List<int>? agentIds = JsonConvert.DeserializeObject<List<int>>(p!["agentIds"]!.ToJsonString()) ?? [];
                
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
                return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Config.GetSupervisorList });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetSupervisorList });
            }
        }

        [HttpPost]
        [Route(template: "Config/GetAgentInfo")]
        public IActionResult GetAgentInfo([FromBody] JsonObject p)
        {
            try
            {
                int agentId = Convert.ToInt32((p["agentId"]??"-1").ToString());
                if (agentId == -1) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Config.GetAgentInfo });

                var info = (from i in _wisedb.AgentInfos
                            where i.AgentID == agentId
                            select i
                            ).SingleOrDefault();
                var acdGroups = (from g in _wisedb.ACDGroupMembers
                                 where g.AgentID == agentId
                                 orderby g.ACDGroupID
                                 select g.ACDGroupID).ToList();
                return Ok(new { result = WiseResult.Success, data = new { info, acdGroups }, function = WiseFunc.Config.GetAgentInfo });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetAgentInfo });
            }
        }
        

        [HttpPost]
        [Route(template: "Config/GetACDGroupAccessList")]
        public IActionResult GetACDGroupAccessList([FromBody] JsonObject p)
        {
            if (p == null) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Config.GetACDGroupAccessList });
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            
            try
            {
                if (p["agentId"] == null)
                {
                    var _list = (from a in _wisedb.ACDGroups orderby a.AcdGroupID select a).ToList();
                    return Ok(new { result = WiseResult.Success, data = _list, function = WiseFunc.Config.GetACDGroupAccessList });
                }
                else
                {
                    bool isAgent = (from a in _wisedb.AgentInfos where a.AgentID == agentId select a).Any();
                    if (!isAgent) return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchAgent, function = WiseFunc.Config.GetACDGroupAccessList });

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

                    return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Config.GetACDGroupAccessList });
                }
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.GetACDGroupAccessList });
            }
        }

        [HttpPost]
        [Route(template: "Config/UpdateACDGroupAccessList")]
        public IActionResult UpdateACDGroupAccessList([FromBody] JsonObject p)
        {
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            if (agentId == -1 || p["setting"] == null) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function= WiseFunc.Config.UpdateACDGroupAccessList });
            
            try
            {

                bool isAgent = (from a in _wisedb.AgentInfos where a.AgentID == agentId select a).Any();
                if (!isAgent) return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchAgent, function = WiseFunc.Config.UpdateACDGroupAccessList });

                List<AcdGroupAccessClass>? setting = JsonConvert.DeserializeObject<List<AcdGroupAccessClass>>(p!["setting"]!.ToJsonString());

                foreach (AcdGroupAccessClass i in setting ?? [])
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
                return Ok(new { result = WiseResult.Success, data, function = WiseFunc.Config.UpdateACDGroupAccessList });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.UpdateACDGroupAccessList });
            }
        }

        [HttpPost]
        [Route(template: "Config/AddACDGroupAccess")]
        public IActionResult AddACDGroupAccess([FromBody] JsonObject p)
        {
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int groupId = Convert.ToInt32((p["groupId"] ?? "-1").ToString());
            if (agentId == -1 || groupId == -1) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Config.AddACDGroupAccess });
            
            try
            {
                bool isAgent = (from a in _wisedb.AgentInfos where a.AgentID == agentId select a).Any();
                if (!isAgent) return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchAgent, function = WiseFunc.Config.AddACDGroupAccess });

                bool isGroup = (from a in _wisedb.ACDGroupMembers where a.ACDGroupID == groupId select a).Any();
                if (!isGroup) return Ok(new { result = WiseResult.Fail, details = "No such ACD Group.", function = WiseFunc.Config.AddACDGroupAccess });

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
                return Ok(new { result = WiseResult.Success, function = WiseFunc.Config.AddACDGroupAccess });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.AddACDGroupAccess });
            }
        }

        [HttpPost]
        [Route(template: "Config/DelACDGroupAccess")]
        public IActionResult DelACDGroupAccess([FromBody] JsonObject p)
        {
            int agentId = Convert.ToInt32((p["agentId"] ?? "-1").ToString());
            int groupId = Convert.ToInt32((p["groupId"] ?? "-1").ToString());

            if (agentId == -1 || groupId == -1) 
                return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters, function = WiseFunc.Config.DelACDGroupAccess});
            try
            {
                bool isAgent = (from a in _wisedb.AgentInfos where a.AgentID == agentId select a).Any();
                if (!isAgent) return Ok(new { result = WiseResult.Fail, details = WiseError.NoSuchAgent, function = WiseFunc.Config.DelACDGroupAccess });

                bool isGroup = (from a in _wisedb.ACDGroupMembers where a.ACDGroupID == groupId select a).Any();
                if (!isGroup) return Ok(new { result = WiseResult.Fail, details = "No such ACD Group.", function = WiseFunc.Config.DelACDGroupAccess });

                var data = (from a in _wisedb.ACDGroup_Accesses
                            where a.AgentID == agentId && a.AcdGroupID == groupId
                            select a).SingleOrDefault();
                if (data == null) return Ok(new { result = WiseResult.Success, function = WiseFunc.Config.DelACDGroupAccess });

                _wisedb.ACDGroup_Accesses.Remove(data);
                _wisedb.SaveChanges();
                return Ok(new { result = WiseResult.Success, function = WiseFunc.Config.DelACDGroupAccess });
            }
            catch (Exception e)
            {
                return Ok(new { result = WiseResult.Fail, data = e.Message, function = WiseFunc.Config.DelACDGroupAccess });
            }
        }
        
    }
}

