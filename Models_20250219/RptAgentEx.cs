using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptAgentEx
{
    public int AgentId { get; set; }

    public string? AgentName { get; set; }

    public int? CallsAnswered { get; set; }

    public int? CallsOutbound { get; set; }

    public int? NotReady { get; set; }

    public int? Playing { get; set; }

    public int? Busy { get; set; }

    public int? TalkTimeAvg { get; set; }

    public int? TalkTimeTotal { get; set; }

    public int? TalkOutbound { get; set; }

    public int? TalkIntercom { get; set; }

    public int? Transfer { get; set; }

    public int? Internal { get; set; }

    public int? AnsweredShort { get; set; }

    public int? DirectLine { get; set; }

    public int? TalkTimeDirectLine { get; set; }

    public int? Login { get; set; }

    public int TypeId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public long? Logintime { get; set; }

    public long? SumTalkTime { get; set; }
}
