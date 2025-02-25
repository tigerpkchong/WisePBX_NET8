using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class ReadyTime
{
    public int CampaignId { get; set; }

    public int StepId { get; set; }

    public int ConditionId { get; set; }

    public string Condition { get; set; } = null!;

    public string Formula { get; set; } = null!;
}
