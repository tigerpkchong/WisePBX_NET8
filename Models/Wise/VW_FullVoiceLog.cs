using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class VW_FullVoiceLog
{
    public int CallID { get; set; }

    public DateTime Begintime { get; set; }

    public string? Filepath { get; set; }

    public string? AgentList { get; set; }

    public string? CallTypeEx { get; set; }

    public string? PhoneNo { get; set; }

    public int ServiceID { get; set; }

    public int CallType { get; set; }

    public string ANI { get; set; } = null!;

    public string DNIS { get; set; } = null!;

    public int Talktime { get; set; }

    public int PrevCallID { get; set; }

    public int NextCallID { get; set; }
}
