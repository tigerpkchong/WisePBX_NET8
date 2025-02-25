using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptAcdex
{
    public string GroupName { get; set; } = null!;

    public int GroupId { get; set; }

    public DateTime TimeStamp { get; set; }

    public int? CallsOffered { get; set; }

    public int? CallsAnswered { get; set; }

    public int? CallsAnsweredAfterThreshold { get; set; }

    public int? CallsAbandoned { get; set; }

    public int? CallsAbandonedAfterThreshold { get; set; }

    public int? ServiceLevel { get; set; }

    public int? CallsOutbound { get; set; }

    public int? AnsweredDelay { get; set; }

    public int? BusyTime { get; set; }

    public int? WaitingTime { get; set; }

    public int? ActiveTime { get; set; }

    public int? InboundTalk { get; set; }

    public int? OutboundTalk { get; set; }

    public int TypeId { get; set; }

    public int? Agentcount { get; set; }

    public long? Logintime { get; set; }

    public long? SumTalkTime { get; set; }
}
