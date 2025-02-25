using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class CallFee
{
    public int CallId { get; set; }

    public int RelatedCallId { get; set; }

    public int CallType { get; set; }

    public string Ani { get; set; } = null!;

    public string Dnis { get; set; } = null!;

    public int ServiceId { get; set; }

    public int DialTime { get; set; }

    public int TotalTalkTime { get; set; }

    public int TotalHoldTime { get; set; }

    public int? TotalConfTime { get; set; }

    public int Answertime { get; set; }

    public int? IvrsHandleTime { get; set; }

    public int? RingTime { get; set; }

    public int? AbanTime { get; set; }

    public DateTime BeginTime { get; set; }

    public DateTime EndTime { get; set; }
}
