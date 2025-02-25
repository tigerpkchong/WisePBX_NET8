using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class TrunkStatus
{
    public int TotalNum { get; set; }

    public int BusyNum { get; set; }

    public int LockNum { get; set; }

    public int InvaidNum { get; set; }

    public int Duration { get; set; }

    public DateTime TimeStamp { get; set; }
}
