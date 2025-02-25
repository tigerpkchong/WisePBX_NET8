using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorConfigTabCtrl
{
    public int LayoutId { get; set; }

    public int TabPageId { get; set; }

    public int CtrlId { get; set; }

    public string CtrlType { get; set; } = null!;

    public int ImageIndex { get; set; }

    public string? Param { get; set; }
}
