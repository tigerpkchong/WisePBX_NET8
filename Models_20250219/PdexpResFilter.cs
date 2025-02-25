using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class PdexpResFilter
{
    public byte ContactRes { get; set; }

    public string RingbackOp { get; set; } = null!;

    public int RingbackSec { get; set; }

    public long Pid { get; set; }
}
