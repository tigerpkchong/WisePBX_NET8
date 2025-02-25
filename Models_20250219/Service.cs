using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceDesc { get; set; } = null!;

    public int Cyc { get; set; }
}
