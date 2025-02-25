using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _MediaController : ControllerBase
    {
        public IActionResult GetCount(int callType, int agentId, string dnis, int handled)
        {
            WiseEntities _wisedb = new WiseEntities();
            int _count = (from m in _wisedb.MediaCalls
                          where m.AgentID == agentId && m.DNIS == dnis && m.IsHandleFinish == handled
                          && m.CallType == callType
                          select m.CallID).Count();
            return Ok(new { result = "success", data = _count });
        }

        public IActionResult AssignAgent(int callType, List<int> mediaIds, int assignTo, int updatedBy)
        {
            WiseEntities _wisedb = new WiseEntities();
            List<Object> data = new List<Object>();

            List<MediaCall> _medialCallList = (from m in _wisedb.MediaCalls
                                               where mediaIds.Contains(m.CallID) && m.CallType == callType //&& m.AgentID != 0
                                               select m).ToList();
            if (_medialCallList != null)
            {
                string details = "";
                foreach (MediaCall _m in _medialCallList)
                {
                    if (_m.IsHandleFinish == 1)
                    {
                        if (details != "") details += " ,";
                        //details += string.Format("Record {0} was already assigned to {1}", _m.CallID, _m.AgentID);
                        details += string.Format("Record {0} was already handled", _m.CallID);
                    }
                }
                if (details != "")
                    return Ok(new { result = "fail", details });

            }
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
            return Ok(new { result = "success", data });
        }

        public IActionResult SetHandled(int callType, int mediaId, string caseNo, int updatedBy)
        {
            WiseEntities _wisedb = new WiseEntities();
            MediaCall? _medialCall = (from m in _wisedb.MediaCalls
                                     where m.CallID == mediaId && m.CallType == callType
                                     select m).SingleOrDefault();
            if (_medialCall == null) 
                return Ok(new { result = "fail", details = "No such record" });

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

            return Ok(new { result = "success", data = _medialCall.DNIS });
        }

        public IActionResult SetRead(int callType, int mediaId, int updatedBy)
        {
            WiseEntities _wisedb = new WiseEntities();
            MediaCall? _medialCall = (from m in _wisedb.MediaCalls
                                     where m.CallID == mediaId && m.CallType == callType
                                     select m).SingleOrDefault();
            if (_medialCall == null) 
                return Ok(new { result = "fail", details = "No such record" });

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

                return Ok(new { result = "success" });
            }
            return Ok(new { result = "fail", details = "it is already read" });
        }

        public IActionResult SetRead(int callType, int[] mediaIds, int updatedBy)
        {
            WiseEntities _wisedb = new WiseEntities();
            List<MediaCall> _medialList = (from m in _wisedb.MediaCalls
                                           where mediaIds.Contains(m.CallID)
                                           && m.CallType == callType
                                           select m).ToList();

            if (_medialList == null) 
                return Ok(new { result = "fail", details = "No such record" });
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
            return Ok(new { result = "success" });
        }

        public IActionResult GetCallid(int callType, int mediaCaseID, int agentID)
        {
            WiseEntities _wisedb = new WiseEntities();
            //int _callId=0;
            MediaCall? _m;
            do
            {
                _m = (from m in _wisedb.MediaCalls
                      where m.CaseID == mediaCaseID && m.CallType == callType
                      select m).SingleOrDefault();
                if (_m == null) System.Threading.Thread.Sleep(500);
            } while (_m == null);
            return Ok(new { result = "success", data = _m.CallID });
            //ScrmEntities _scrmdb = new ScrmEntities();
        }
    }
}
