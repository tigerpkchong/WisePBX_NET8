using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class ServiceReport
{
    public string? ServiceName { get; set; }

    public string ServiceId { get; set; } = null!;

    public string? IsVaild { get; set; }

    public int? Sort { get; set; }
}
