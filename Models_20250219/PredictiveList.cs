using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class PredictiveList
{
    public int CampaignId { get; set; }

    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string Telephone { get; set; } = null!;

    public int? Attempt { get; set; }

    public int? ContactResult { get; set; }

    public int? CurrConnId { get; set; }

    public int? CurrCallId { get; set; }

    public DateTime? ContactTime { get; set; }

    public DateTime? ScheduleTime { get; set; }

    public int? DeviceType { get; set; }

    public int? DeviceId { get; set; }

    public int? IbusinessFlag { get; set; }

    public string? Remarks { get; set; }

    public int? MaxTalk { get; set; }

    public int? CustStatus { get; set; }

    public string? Telephone1 { get; set; }

    public string? Telephone2 { get; set; }

    public string? Telephone3 { get; set; }

    public int? ContactResult1 { get; set; }

    public int? ContactResult2 { get; set; }

    public int? ContactResult3 { get; set; }

    public int? TeleIndex { get; set; }

    public int? Ivrs { get; set; }

    public string? Ani { get; set; }

    public string? SessionId { get; set; }

    public string? Audio { get; set; }

    public string? FallbackAudio { get; set; }
}
