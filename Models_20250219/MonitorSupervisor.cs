using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorSupervisor
{
    public int Itemid { get; set; }

    public int Wiseid { get; set; }

    public int Supervisorid { get; set; }

    public int IsFullControl { get; set; }

    public string Rights { get; set; } = null!;

    public string SendAni { get; set; } = null!;

    public string TransactUser { get; set; } = null!;

    public DateTime TransactDate { get; set; }
}
