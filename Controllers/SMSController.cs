﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SMSController(WiseEntities wiseEntities) : ControllerBase
    {
        private readonly WiseEntities _wisedb= wiseEntities;

        [HttpPost]
        public IActionResult GetContent([FromBody] dynamic p)
        {
            int id = (p.id == null) ? -1 : Convert.ToInt32(p.id.Value);
            if (id == -1) return Ok(new { result = WiseResult.Fail, details = WiseError.InvalidParameters });
            MediaCall? _mediaCall = (from m in _wisedb.MediaCalls
                                    where m.CallID == id && m.CallType == 15
                                    select m).SingleOrDefault();
            if (_mediaCall == null) return Ok(new { result = WiseResult.Fail, WiseError.NoSuchRecord });
            var data = new { MobileNo = _mediaCall.DNIS, Message = _mediaCall.Subject };
            return Ok(new { result = WiseResult.Success, data });
        }
    }
}
