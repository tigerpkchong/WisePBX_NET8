using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class WiseWallBoardParameter
{
    public string Parameter { get; set; } = null!;

    public string? PValue { get; set; }
}
