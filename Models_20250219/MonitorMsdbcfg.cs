using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorMsdbcfg
{
    public int Pid { get; set; }

    public string Server { get; set; } = null!;

    public string Db { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Description { get; set; } = null!;
}
