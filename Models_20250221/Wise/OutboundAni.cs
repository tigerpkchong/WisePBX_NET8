using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class OutboundANI
{
    public string ServiceName { get; set; } = null!;

    public string OutboundType { get; set; } = null!;

    public string? ANI { get; set; }
}
