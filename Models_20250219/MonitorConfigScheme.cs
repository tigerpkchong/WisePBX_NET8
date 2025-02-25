using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorConfigScheme
{
    public int SchemeId { get; set; }

    public string SchemeName { get; set; } = null!;

    public int AgentId { get; set; }
}
