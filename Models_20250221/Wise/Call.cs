using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class Call
{
    public int CallID { get; set; }

    public int CaseID { get; set; }

    public int Calltype { get; set; }

    public string ANI { get; set; } = null!;

    public string DNIS { get; set; } = null!;

    public int ServiceID { get; set; }

    public int? Self_defineID { get; set; }

    public int PrevCallID { get; set; }

    public int NextCallID { get; set; }

    public int Talktime { get; set; }

    public int Holdtime { get; set; }

    public int Receivedtime { get; set; }

    public int Iwaitingtime { get; set; }

    public int Owaitingtime { get; set; }

    public int Dialingtime { get; set; }

    public int Ringbacktime { get; set; }

    public int oDeviceType { get; set; }

    public int oDeviceGroup { get; set; }

    public int oDeviceID { get; set; }

    public int dDeviceType { get; set; }

    public int dDeviceGroup { get; set; }

    public int dDeviceID { get; set; }

    public int ResultID { get; set; }

    public int OverflowFlag { get; set; }

    public int HoldCallID { get; set; }

    public int Recordnumber { get; set; }

    public DateTime Begintime { get; set; }

    public DateTime Endtime { get; set; }

    public byte LeaveMsg { get; set; }
}
