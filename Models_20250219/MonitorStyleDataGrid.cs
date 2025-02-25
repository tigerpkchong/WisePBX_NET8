using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorStyleDataGrid
{
    public int Uid { get; set; }

    public string Style { get; set; } = null!;

    public string Colorheader { get; set; } = null!;

    public string Colorheaderbg { get; set; } = null!;

    public string Colorgrid { get; set; } = null!;

    public string Colorrow { get; set; } = null!;

    public string Coloralter { get; set; } = null!;
}
