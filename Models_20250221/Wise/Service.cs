using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class Service
{
    public int ServiceID { get; set; }

    public string ServiceDesc { get; set; } = null!;

    public int Cyc { get; set; }
}
