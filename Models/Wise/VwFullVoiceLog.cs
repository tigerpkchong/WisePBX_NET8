using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class VwFullVoiceLog
{
    public int CallId { get; set; }

    public DateTime Begintime { get; set; }

    public string? Filepath { get; set; }

    public string? AgentList { get; set; }

    public string? CallTypeEx { get; set; }

    public string? PhoneNo { get; set; }

    public int ServiceId { get; set; }

    public int CallType { get; set; }

    public string Ani { get; set; } = null!;

    public string Dnis { get; set; } = null!;

    public int Talktime { get; set; }

    public int PrevCallId { get; set; }

    public int NextCallId { get; set; }
}
