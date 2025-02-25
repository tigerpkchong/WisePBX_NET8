using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorTranLog
{
    public long Id { get; set; }

    public DateTime TimeStamp { get; set; }

    public DateTime? EndTime { get; set; }

    public int OdeviceType { get; set; }

    public int OdeviceId { get; set; }

    public int DdeviceType { get; set; }

    public int DdeviceId { get; set; }

    public int? CallId { get; set; }
}
