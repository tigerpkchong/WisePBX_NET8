using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class StationUsage
{
    public DateTime RpDate { get; set; }

    public int? DeviceType { get; set; }

    public int? DeviceId { get; set; }

    public int? TotalNo { get; set; }

    public int? Busy { get; set; }
}
