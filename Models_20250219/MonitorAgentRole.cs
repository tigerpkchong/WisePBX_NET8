using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorAgentRole
{
    public int Uid { get; set; }

    public int AgentId { get; set; }

    public string? ListAgentId { get; set; }

    public int RootAgentId { get; set; }
}
