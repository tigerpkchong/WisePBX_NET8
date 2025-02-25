using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class WiseWallBoardRpt
{
    public int ServId { get; set; }

    public int Mcid { get; set; }

    public int BHandled { get; set; }

    public long ResCount { get; set; }
}
