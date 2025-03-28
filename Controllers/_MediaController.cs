using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _MediaController : ControllerBase
    {
        private readonly string strSuccess = "success";
        private readonly string strFail = "fail";

        private readonly WiseEntities _wisedb;
        public _MediaController(WiseEntities wiseEntities) 
        {
            _wisedb = wiseEntities;
        }

        [HttpPost]
        public IActionResult GetCount(int callType, int agentId, string dnis, int handled)
        {
            int _count = (from m in _wisedb.MediaCalls
                          where m.AgentID == agentId && m.DNIS == dnis && m.IsHandleFinish == handled
                          && m.CallType == callType
                          select m.CallID).Count();
            return Ok(new { result = strSuccess, data = _count });
        }

        private static string CheckHandled(WiseEntities _wisedb, int callType, List<int> mediaIds)
        {
            var _medialCallList = (from m in _wisedb.MediaCalls
                                               where mediaIds.Contains(m.CallID) && m.CallType == callType //&& m.AgentID != 0
                                               select m).AsEnumerable();
            if (!_medialCallList.Any()) return "";
            string details = "";
            foreach (var _m in _medialCallList)
            {
                if (_m.IsHandleFinish == 1)
                {
                    if (details != "") details += " ,";
                    details += string.Format("Record {0} was already handled", _m.CallID);
                }
            }

            return details;
        }
        [HttpPost]
        public IActionResult AssignAgent(int callType, List<int> mediaIds, int assignTo, int updatedBy)
        {
            string details = CheckHandled(_wisedb, callType, mediaIds);
            if (details != "")
                return Ok(new { result = strFail, details });
            
            List<Object> data = new List<Object>();
            foreach (int mediaId in mediaIds)
            {
                MediaCall? _medialCall = (from m in _wisedb.MediaCalls
                                         where m.CallID == mediaId && m.CallType == callType
                                         select m).SingleOrDefault();
                
                if (_medialCall != null)
                {

                    _medialCall.AgentID = assignTo;
                    
                    _wisedb.MediaCall_Action_Logs.Add(new MediaCall_Action_Log()
                    {
                        CallId = mediaId,
                        AgentId = assignTo,
                        Action = "Assign",
                        Updated_By = updatedBy,
                        Updated_Time = DateTime.Now
                    });
                    
                    _wisedb.SaveChanges();
                    data.Add(new { mediaId, dnis = _medialCall.DNIS });
                }
                
            }
            return Ok(new { result = strSuccess, data });
        }
        [HttpPost]
        public IActionResult SetHandled(int callType, int mediaId, string caseNo, int updatedBy)
        {
            MediaCall? _medialCall = (from m in _wisedb.MediaCalls
                                     where m.CallID == mediaId && m.CallType == callType
                                     select m).SingleOrDefault();
            if (_medialCall == null) 
                return Ok(new { result = strFail, details = "No such record" });

            if (_medialCall.IsHandleFinish == 0)
            {
                _medialCall.IsHandleFinish = 1;
                _medialCall.HandledNo = caseNo;
                _medialCall.HandleDateTime = DateTime.Now;
                _wisedb.SaveChanges();
            }
            _wisedb.MediaCall_Action_Logs.Add(new MediaCall_Action_Log()
            {
                CallId = mediaId,
                AgentId = null,
                Action = "Handled",
                Updated_By = updatedBy,
                Updated_Time = DateTime.Now
            });
            _wisedb.SaveChanges();

            return Ok(new { result = strSuccess, data = _medialCall.DNIS });
        }
        [HttpPost]
        public IActionResult SetRead(int callType, int mediaId, int updatedBy)
        {
            MediaCall? _medialCall = (from m in _wisedb.MediaCalls
                                     where m.CallID == mediaId && m.CallType == callType
                                     select m).SingleOrDefault();
            if (_medialCall == null) 
                return Ok(new { result = strFail, details = "No such record" });

            if (_medialCall.ReadFlag == 0)
            {
                _medialCall.ReadFlag = 1;

                _medialCall.HandleDateTime = DateTime.Now;
                _wisedb.SaveChanges();

                _wisedb.MediaCall_Action_Logs.Add(new MediaCall_Action_Log()
                {
                    CallId = mediaId,
                    AgentId = null,
                    Action = "Read",
                    Updated_By = updatedBy,
                    Updated_Time = DateTime.Now
                });
                _wisedb.SaveChanges();

                return Ok(new { result = strSuccess });
            }
            return Ok(new { result = strFail, details = "it is already read" });
        }
        [HttpPost]
        public IActionResult SetRead(int callType, int[] mediaIds, int updatedBy)
        {
            var _medialList = (from m in _wisedb.MediaCalls
                                           where mediaIds.Contains(m.CallID)
                                           && m.CallType == callType
                                           select m).ToList();

            if (_medialList.Count == 0) 
                return Ok(new { result = strFail, details = "No such record" });
            foreach (MediaCall _medialCall in _medialList)
            {
                if (_medialCall.ReadFlag == 0)
                {
                    _medialCall.ReadFlag = 1;

                    _medialCall.HandleDateTime = DateTime.Now;
                    _wisedb.SaveChanges();

                    _wisedb.MediaCall_Action_Logs.Add(new MediaCall_Action_Log()
                    {
                        CallId = _medialCall.CallID,
                        AgentId = null,
                        Action = "Read",
                        Updated_By = updatedBy,
                        Updated_Time = DateTime.Now
                    });
                    _wisedb.SaveChanges();
                }
            }
            return Ok(new { result = strSuccess });
        }
        [HttpPost]
        public IActionResult GetCallid(int callType, int mediaCaseID)
        {
            MediaCall? _m;
            do
            {
                _m = (from m in _wisedb.MediaCalls
                      where m.CaseID == mediaCaseID && m.CallType == callType
                      select m).SingleOrDefault();
                if (_m == null) System.Threading.Thread.Sleep(500);
            } while (_m == null);
            return Ok(new { result = strSuccess, data = _m.CallID });
        }
    }
}
