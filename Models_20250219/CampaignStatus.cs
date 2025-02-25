using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class CampaignStatus
{
    public int CampaignId { get; set; }

    public int? NowAttempt { get; set; }
}
