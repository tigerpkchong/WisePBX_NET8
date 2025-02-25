using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class WorkingTime
{
    public int CampaignId { get; set; }

    public int StepId { get; set; }

    public int WorkingTimeRef { get; set; }
}
