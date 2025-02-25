using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class PredictiveLog
{
    public int CustomerId { get; set; }

    public int CampaignId { get; set; }

    public int Attempt { get; set; }

    public int CallId { get; set; }

    public int ContactResult { get; set; }

    public DateTime ContactTime { get; set; }

    public string Telephone { get; set; } = null!;
}
