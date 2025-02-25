using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorConfigRest
{
    public int Uid { get; set; }

    public string Name { get; set; } = null!;

    public string? Dispname { get; set; }

    public string Color { get; set; } = null!;

    public int AgentId { get; set; }

    public byte Sn { get; set; }
}
