using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptServiceIn
{
    public int ServiceId { get; set; }

    public int TypeId { get; set; }

    public int CallInbound { get; set; }

    public int CallAcdqueue { get; set; }

    public int CallSelectAgent { get; set; }

    public int CallAgentHandle { get; set; }

    public int CallIvrsHandle { get; set; }

    public int CallOverFlow { get; set; }

    public int SumRingTime { get; set; }

    public int MaxRingTime { get; set; }

    public double AvgRingTime { get; set; }

    public int SumAnswerTime { get; set; }

    public int MaxAnswerTime { get; set; }

    public double AvgAnswerTime { get; set; }

    public int AnswerCnt { get; set; }

    public int SumAbanTime { get; set; }

    public int MaxAbanTime { get; set; }

    public double AvgAbanTime { get; set; }

    public int AbanCnt { get; set; }

    public int VmailCnt { get; set; }

    public int SumTalkTime { get; set; }

    public int MaxTalkTime { get; set; }

    public double AvgTalkTime { get; set; }

    public int SumHoldTime { get; set; }

    public int MaxHoldTime { get; set; }

    public double AvgHoldTime { get; set; }

    public int CallAswt05 { get; set; }

    public int CallAswt10 { get; set; }

    public int CallAswt15 { get; set; }

    public int CallAswt20 { get; set; }

    public int CallAswt25 { get; set; }

    public int CallAswt30 { get; set; }

    public int CallAswt35 { get; set; }

    public int CallAswt40 { get; set; }

    public int CallAswt45 { get; set; }

    public int CallAswt50 { get; set; }

    public int CallAswtElse { get; set; }

    public int Cyc { get; set; }

    public DateTime TimeStamp { get; set; }

    public int SumIvrsHandleTime { get; set; }

    public int MaxIvrsHandleTime { get; set; }

    public int AvgIvrsHandleTime { get; set; }

    public int HoldCnt { get; set; }

    public int CallAbandon05 { get; set; }

    public int CallAbandon10 { get; set; }

    public int CallAbandon15 { get; set; }

    public int CallAbandon20 { get; set; }

    public int CallAbandon25 { get; set; }

    public int CallAbandon30 { get; set; }

    public int CallAbandon35 { get; set; }

    public int CallAbandon40 { get; set; }

    public int CallAbandon45 { get; set; }

    public int CallAbandon50 { get; set; }

    public int CallAbandonElse { get; set; }
}
