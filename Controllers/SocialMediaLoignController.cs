using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Json.Nodes;
using WisePBX.NET8.Models.SConnector;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Controllers
{
    [Route(template:"api")]
    [ApiController]
    public class SocialMediaLoignController(WiseEntities wEntities) : ControllerBase
    {
        private readonly WiseEntities _wiseDB = wEntities;
        
        [HttpPost]
        [Route(template: "SocialMedia/Login")]
        public IActionResult Login([FromBody] JsonObject data)
        {
            if (data == null) return Ok(new { result = WiseResult.Fail, details = "Invalid login." });

            int sellerId = Convert.ToInt32((data["SellerID"] ?? "0").ToString());
            string password = (data["Password"] ?? "").ToString();

            var _r = (from m in _wiseDB.AgentInfos
                      where m.AgentID == sellerId && (m.Password ?? "").Substring(0, 3000) == password
                      select new
                      {
                          ColId = 1,
                          m.AgentID,
                          m.AgentName,
                          m.LevelID,
                          SellerID = "" + m.AgentID + "",
                          Counter = 0,
                          ExpiryDate = "",
                          LastLoginDate = "",
                          Account_status = "Active",
                          Email = "",
                          RoleName = "ETS Supervisor",
                          Companies = "campaignCRM",
                          Categories = "FB-Post,Menu,Overdue-Reminder,Scheduled-Reminder,System-Tools",
                          Functions = "Admin-Transfer,Escalation-List,Incomplete-Cases,Escalation-List-Fn,Incomplete-Cases-Fn,Overdue-Reminder-Fn,Search-Case-Fn,Search-Case,Search-Customer",
                          config = new List<object> { new { P_Id = 1, P_Name = "RecordPerPage_Case", P_Value="5" },
                                new { P_Id = 2, P_Name = "RecordPerPage_Case_Log", P_Value="5" },
                                new { P_Id = 3, P_Name = "PhotoSize_MB", P_Value="5" },
                                new { P_Id = 4, P_Name = "PasswordChangeFrequency", P_Value="180" }
                           }

                      }).SingleOrDefault();

            if (_r == null)
                return Ok(new { result = WiseResult.Fail, details = "Invalid login." });

            return Ok(new { result = WiseResult.Success, details = _r });
        }
        
    }
}
