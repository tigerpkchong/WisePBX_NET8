using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class WebRptType
{
    public int Uid { get; set; }

    public string TypeStr { get; set; } = null!;

    public string Description { get; set; } = null!;
}
