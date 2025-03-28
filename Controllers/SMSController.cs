﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly WiseEntities _wisedb;
        public SMSController(WiseEntities entities) 
        {
            _wisedb = entities;
        }

        [HttpPost]
        public IActionResult GetContent([FromBody] dynamic p)
        {
            int id = (p.id == null) ? -1 : Convert.ToInt32(p.id.Value);
            if (id == -1) return Ok(new { result = "fail", details = "Invalid Parameters." });
            MediaCall? _mediaCall = (from m in _wisedb.MediaCalls
                                    where m.CallID == id && m.CallType == 15
                                    select m).SingleOrDefault();
            if (_mediaCall == null) return Ok(new { result = "fail", details = "No such record" });
            var data = new { MobileNo = _mediaCall.DNIS, Message = _mediaCall.Subject };
            return Ok(new { result = "success", data });
        }
    }
}
