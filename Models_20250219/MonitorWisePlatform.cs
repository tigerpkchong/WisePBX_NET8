using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorWisePlatform
{
    public int Wiseid { get; set; }

    public string WiseName { get; set; } = null!;

    public string WiseRmserver { get; set; } = null!;

    public string Odbc1 { get; set; } = null!;

    public string Odbc2 { get; set; } = null!;

    public string TransactUser { get; set; } = null!;

    public DateTime TransactDate { get; set; }
}
