using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptStationTime
{
    public int RecordId { get; set; }

    public int DeviceType { get; set; }

    public int DeviceId { get; set; }

    public string Extension { get; set; } = null!;

    public DateTime TimeStamp { get; set; }

    public DateTime WriteDbtime { get; set; }

    public int InCallCount { get; set; }

    public int PickupCallCount { get; set; }

    public int OutCallCount { get; set; }

    public int InInterCount { get; set; }

    public int OutInterCount { get; set; }

    public int AnsCount { get; set; }

    public decimal InTalkTime { get; set; }

    public decimal InTalkTimeMax { get; set; }

    public decimal OutTalkTime { get; set; }

    public decimal OutTalkTimeMax { get; set; }

    public decimal InterTalkTime { get; set; }

    public decimal InterTalkTimeMax { get; set; }
}
