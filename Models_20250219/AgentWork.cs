using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AgentWork
{
    public int AgentId { get; set; }

    public int CallId { get; set; }

    public int DealOrder { get; set; }

    public int CallType { get; set; }

    public int TotalTalkTime { get; set; }

    public int TotalHoldTime { get; set; }

    public int TotalWorkTime { get; set; }

    public DateTime BeginTime { get; set; }

    public DateTime EndTime { get; set; }
}
