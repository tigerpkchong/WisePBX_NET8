using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class WiseDbChangeLog
{
    public int RecordId { get; set; }

    public DateTime TimeStamp { get; set; }

    public string Version { get; set; } = null!;
}
