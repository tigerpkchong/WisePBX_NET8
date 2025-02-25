using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorStatistic
{
    public DateTime TimeStamp { get; set; }

    public int ServiceId { get; set; }

    public int AcdgroupId { get; set; }

    public string? AcdgroupType { get; set; }

    public int? IncomingCall { get; set; }

    public int? AnsweredCall { get; set; }

    public int? AbandonedCall { get; set; }

    public int? OutboundCall { get; set; }

    public int? AbandonedTime { get; set; }

    public int? AnsweredWaitTime { get; set; }

    public int? AnsweredTalkTime { get; set; }

    public int? OutboundTalkTime { get; set; }

    public int? PctAbandonedCall { get; set; }

    public int? AvgAbandonedTime { get; set; }
}
