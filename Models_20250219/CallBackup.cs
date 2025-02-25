using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class CallBackup
{
    public int CallId { get; set; }

    public int CaseId { get; set; }

    public int Calltype { get; set; }

    public string Ani { get; set; } = null!;

    public string Dnis { get; set; } = null!;

    public int ServiceId { get; set; }

    public int? SelfDefineId { get; set; }

    public int PrevCallId { get; set; }

    public int NextCallId { get; set; }

    public int Talktime { get; set; }

    public int Holdtime { get; set; }

    public int Receivedtime { get; set; }

    public int Iwaitingtime { get; set; }

    public int Owaitingtime { get; set; }

    public int Dialingtime { get; set; }

    public int Ringbacktime { get; set; }

    public int ODeviceType { get; set; }

    public int ODeviceGroup { get; set; }

    public int ODeviceId { get; set; }

    public int DDeviceType { get; set; }

    public int DDeviceGroup { get; set; }

    public int DDeviceId { get; set; }

    public int ResultId { get; set; }

    public int OverflowFlag { get; set; }

    public int HoldCallId { get; set; }

    public int Recordnumber { get; set; }

    public DateTime Begintime { get; set; }

    public DateTime Endtime { get; set; }

    public byte LeaveMsg { get; set; }

    public byte? VoiceMail { get; set; }

    public int? Vmduration { get; set; }
}
