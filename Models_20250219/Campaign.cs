using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class Campaign
{
    public int CampaignId { get; set; }

    public decimal? ServiceId { get; set; }

    public byte? Enable { get; set; }

    public int? Active { get; set; }

    public string? PrefixNumber { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? MaxOutBoundCall { get; set; }

    public int? AttemptCount { get; set; }

    public string? ContactResult { get; set; }

    public int? IntervalTime { get; set; }

    public int? DeviceType { get; set; }

    public int? DeviceId { get; set; }

    public decimal? DialOutRatio { get; set; }

    public string? Ani { get; set; }

    public DateTime? MonStartTime { get; set; }

    public DateTime? MonEndTime { get; set; }

    public DateTime? TueStartTime { get; set; }

    public DateTime? TueEndTime { get; set; }

    public DateTime? WedStartTime { get; set; }

    public DateTime? WedEndTime { get; set; }

    public DateTime? ThuStartTime { get; set; }

    public DateTime? ThuEndTime { get; set; }

    public DateTime? FriStartTime { get; set; }

    public DateTime? FriEndTime { get; set; }

    public DateTime? SatStartTime { get; set; }

    public DateTime? SatEndTime { get; set; }

    public DateTime? SunStartTime { get; set; }

    public DateTime? SunEndTime { get; set; }

    public int? TeleFlag1 { get; set; }

    public int? TeleFlag2 { get; set; }

    public int? TeleFlag3 { get; set; }

    public int? TeleFlag4 { get; set; }

    public byte? OrderField { get; set; }

    public byte? Tele1stIndex { get; set; }

    public string? Remark { get; set; }
}
