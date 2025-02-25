using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorConfigDatum
{
    public int Uid { get; set; }

    public int AgentId { get; set; }

    public string CfgName { get; set; } = null!;

    public byte[] CfgData { get; set; } = null!;

    public int Typeid { get; set; }
}
