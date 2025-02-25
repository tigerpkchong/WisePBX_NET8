using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class SpaceUsage
{
    public int Uid { get; set; }

    public DateTime RpDate { get; set; }

    public int TableId { get; set; }

    public int TotalRows { get; set; }

    public int TotalDataSize { get; set; }

    public int TotalIndexSize { get; set; }
}
