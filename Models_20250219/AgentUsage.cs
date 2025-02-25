using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AgentUsage
{
    public DateTime RpDate { get; set; }

    public int? DeviceType { get; set; }

    public int? DeviceId { get; set; }

    public int? TotalNo { get; set; }

    public int? Idle { get; set; }

    public int? Ready { get; set; }

    public int? Break { get; set; }

    public int? Hold { get; set; }

    public int? Talk { get; set; }

    public int? Work { get; set; }

    public int? Dial { get; set; }

    public int? Play { get; set; }

    public int? Monitor { get; set; }

    public int? Others { get; set; }
}
