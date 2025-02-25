using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptServiceOut
{
    public int ServiceId { get; set; }

    public int TypeId { get; set; }

    public int CallOutbound { get; set; }

    public int CallOutTalk { get; set; }

    public int CallIdel { get; set; }

    public int CallPending { get; set; }

    public int CallNoserver { get; set; }

    public int CallBlock { get; set; }

    public int CallQueue { get; set; }

    public int CallHoldQueue { get; set; }

    public int CallDialing { get; set; }

    public int CallRingBack { get; set; }

    public int CallHangupQueue { get; set; }

    public int CallHangupDial { get; set; }

    public int CallHangupRing { get; set; }

    public int CallFail { get; set; }

    public int CallBusy { get; set; }

    public int CallWrongTelNo { get; set; }

    public int CallNoResource { get; set; }

    public int CallRingFail { get; set; }

    public int CallTimeOut { get; set; }

    public int CallRingCustHangup { get; set; }

    public int CallHoldDial { get; set; }

    public int CallHoldRing { get; set; }

    public int CallHoldFail { get; set; }

    public int CallNoAnswer { get; set; }

    public int CallNoDialTone { get; set; }

    public int CallOtherResult { get; set; }

    public int SumDialTime { get; set; }

    public int MaxDialTime { get; set; }

    public double AvgDialTime { get; set; }

    public int SumRingTime { get; set; }

    public int MaxRingTime { get; set; }

    public double AvgRingTime { get; set; }

    public int SumTalkTime { get; set; }

    public int MaxTalkTime { get; set; }

    public double AvgTalkTime { get; set; }

    public int SumHoldTime { get; set; }

    public int MaxHoldTime { get; set; }

    public double AvgHoldTime { get; set; }

    public DateTime TimeStamp { get; set; }
}
