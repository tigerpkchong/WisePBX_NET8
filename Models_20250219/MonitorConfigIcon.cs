using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorConfigIcon
{
    public int Uid { get; set; }

    public string Name { get; set; } = null!;

    public string Cname { get; set; } = null!;

    public string? Dispname { get; set; }

    public string? Color { get; set; }

    public DateTime? Timelimit { get; set; }

    public int? AgentId { get; set; }

    public int? Sn { get; set; }
}
