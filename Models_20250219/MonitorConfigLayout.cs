using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorConfigLayout
{
    public int LayoutId { get; set; }

    public string LayoutName { get; set; } = null!;

    public int AgentId { get; set; }

    public byte[] LayoutData { get; set; } = null!;
}
