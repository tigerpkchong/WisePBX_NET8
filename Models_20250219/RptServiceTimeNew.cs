using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptServiceTimeNew
{
    public int? ServiceId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public DateTime? WriteDbtime { get; set; }

    public int? AnsweredCall { get; set; }

    public int? AbandonedCall { get; set; }

    public int? IvrsOnly { get; set; }

    public int? Voicemail { get; set; }

    public int? Sla40 { get; set; }

    public int? InEmail { get; set; }

    public int? OutboundCount { get; set; }

    public int? WaitingTime { get; set; }

    public int? InTalkTime { get; set; }

    public int? OutTalkTime { get; set; }

    public int? InWorkingTime { get; set; }

    public int? OutWorkingTime { get; set; }

    public int? AbandonedTime { get; set; }
}
