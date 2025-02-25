using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptAgentLogin
{
    public int AgentId { get; set; }

    public string LoginTime { get; set; } = null!;

    public string LogoutTime { get; set; } = null!;

    public string Station { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public DateTime TimeStamp { get; set; }
}
