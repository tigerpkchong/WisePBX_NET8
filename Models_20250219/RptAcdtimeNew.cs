using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptAcdtimeNew
{
    public int? AcdgroupId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public DateTime? WriteDbtime { get; set; }

    public int? AnswerCount { get; set; }

    public int? AbandonCount { get; set; }

    public int? VoiceMailCount { get; set; }

    public int? Sla5count { get; set; }

    public int? Sla10count { get; set; }

    public int? Sla15count { get; set; }

    public int? Sla20count { get; set; }

    public int? Sla30count { get; set; }

    public int? Sla40count { get; set; }

    public int? Sla50count { get; set; }

    public int? Sla60count { get; set; }

    public int? Sla90count { get; set; }

    public int? Sla120count { get; set; }

    public int? WaitingTime { get; set; }

    public int? AbandonTime { get; set; }

    public int? InTalktime { get; set; }

    public int? InWorkingTime { get; set; }

    public int? OutboundCount { get; set; }

    public int? OutTalkTime { get; set; }

    public int? OutWorkingTime { get; set; }

    public int? SpreadOfAnswerTime { get; set; }

    public int? SpreadOfAnswerCount { get; set; }

    public int? TotalAcdCallCount { get; set; }
}
