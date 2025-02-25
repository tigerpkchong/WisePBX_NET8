using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorAgentConfig
{
    public int Uid { get; set; }

    public int AgentId { get; set; }

    public string? Style { get; set; }

    public int Layoutid { get; set; }

    public string? Iconviewitem { get; set; }
}
