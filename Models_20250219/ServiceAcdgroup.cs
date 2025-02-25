using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class ServiceAcdgroup
{
    public int ServiceId { get; set; }

    public int AcdgroupId { get; set; }

    public string? AcdgroupType { get; set; }
}
