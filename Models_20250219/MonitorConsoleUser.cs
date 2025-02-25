using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorConsoleUser
{
    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string TransactUser { get; set; } = null!;

    public DateTime TransactDate { get; set; }
}
