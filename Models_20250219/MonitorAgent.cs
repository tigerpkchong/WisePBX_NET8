using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorAgent
{
    public int Itemid { get; set; }

    public int Wiseid { get; set; }

    public int Supervisorid { get; set; }

    public int Agentid { get; set; }

    public string TransactUser { get; set; } = null!;

    public DateTime TransactDate { get; set; }
}
