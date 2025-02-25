using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class OutboundAni
{
    public string ServiceName { get; set; } = null!;

    public string OutboundType { get; set; } = null!;

    public string? Ani { get; set; }
}
