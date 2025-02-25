using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class WiseWbacdrpt
{
    public int AcdgrpId { get; set; }

    public string WaitTime { get; set; } = null!;

    public double ServLv { get; set; }
}
