using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorConfigTabPage
{
    public int LayoutId { get; set; }

    public int TabPageId { get; set; }

    public string TabPageName { get; set; } = null!;

    public int ActiveCtrlId { get; set; }
}
