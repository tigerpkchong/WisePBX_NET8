using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class SlaChangeLog
{
    public int RecordId { get; set; }

    public DateTime TimeStamp { get; set; }

    public int Sla01 { get; set; }

    public int Sla02 { get; set; }

    public int Sla03 { get; set; }
}
