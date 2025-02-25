using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class PredictiveDialOutLog
{
    public int CampaignId { get; set; }

    public DateTime TimeStamp { get; set; }

    public int AvgTalkTime { get; set; }

    public int MaxTalkTime { get; set; }

    public int AvgReadyTime { get; set; }

    public int MaxReadyTime { get; set; }

    public string DropCallRatio { get; set; } = null!;

    public decimal? DialOutRatio { get; set; }
}
