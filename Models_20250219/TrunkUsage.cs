using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class TrunkUsage
{
    public DateTime RpDate { get; set; }

    public int? DeviceType { get; set; }

    public int? DeviceId { get; set; }

    public int? TotalNo { get; set; }

    public int? Idle { get; set; }

    public int? Busy { get; set; }

    public int? Reserved { get; set; }

    public double? Utilization { get; set; }

    public int? Inbound { get; set; }

    public int? Outbound { get; set; }
}
