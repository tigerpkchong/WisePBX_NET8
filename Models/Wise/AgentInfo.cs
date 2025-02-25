using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class AgentInfo
{
    public int AgentID { get; set; }

    public string? AgentName { get; set; }

    public string? Password { get; set; }

    public int? LevelID { get; set; }

    public int? RecordFlag { get; set; }

    public byte InboundFlag { get; set; }

    public byte OutboundFlag { get; set; }

    public byte PDFlag { get; set; }

    public byte VideoCap { get; set; }
}
