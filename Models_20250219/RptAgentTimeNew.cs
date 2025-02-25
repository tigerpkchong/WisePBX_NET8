using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptAgentTimeNew
{
    public int? AgentId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public DateTime? WriteDbtime { get; set; }

    public int? AnsweredCall { get; set; }

    public int? VoiceMail { get; set; }

    public int? OutboundSuccessCall { get; set; }

    public int? OutboundAttemptCall { get; set; }

    public int? LoginTime { get; set; }

    public int? InTalkTime { get; set; }

    public int? OutTalkTime { get; set; }

    public int? InWorkingTime { get; set; }

    public int? OutWorkingTime { get; set; }

    public int? IdleTime { get; set; }

    public int? ReadyTime { get; set; }

    public int? MiscDutyTime { get; set; }

    public int? MiscEscalateTime { get; set; }

    public int? MiscRestTime { get; set; }

    public int? MiscOtherTime { get; set; }

    public int? OtherTime { get; set; }

    public int? HoldCallTime { get; set; }
}
