using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AgentInfo
{
    public int AgentId { get; set; }

    public string? AgentName { get; set; }

    public string? Password { get; set; }

    public int? LevelId { get; set; }

    public int? RecordFlag { get; set; }

    public byte InboundFlag { get; set; }

    public byte OutboundFlag { get; set; }

    public byte Pdflag { get; set; }

    public byte VideoCap { get; set; }
}
