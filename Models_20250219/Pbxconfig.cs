using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class Pbxconfig
{
    public string Name { get; set; } = null!;

    public string? ValueString { get; set; }
}
