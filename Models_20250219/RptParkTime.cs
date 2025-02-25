using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptParkTime
{
    public int RecordId { get; set; }

    public int ParkId { get; set; }

    public DateTime TimeStamp { get; set; }

    public DateTime WriteDbtime { get; set; }

    public int InCallOfferCount { get; set; }

    public int InCallQueueCount { get; set; }

    public int InCallOfferCountBfwd { get; set; }

    public int AbandonCallCount { get; set; }

    public int AbanCallAfterThresCount { get; set; }

    public int AbanThreshold { get; set; }

    public int InCallAnsNoWaitCount { get; set; }

    public int InCallAnsSla01count { get; set; }

    public int InCallAnsSla02count { get; set; }

    public int InCallAnsSla03count { get; set; }

    public int InCallAnsOthersCount { get; set; }

    public int InCallAnsCountBfwd { get; set; }

    public int Sla01 { get; set; }

    public int Sla02 { get; set; }

    public int Sla03 { get; set; }

    public decimal InWaitingTime { get; set; }

    public decimal InWaitingTimeMax { get; set; }

    public decimal InAbandonTime { get; set; }

    public decimal InAbandonTimeMax { get; set; }

    public int MediaInEmailU { get; set; }

    public int MediaInFaxU { get; set; }

    public int MediaInSmsU { get; set; }

    public int MediaInWebCallU { get; set; }

    public int MediaInWebChatU { get; set; }

    public int MediaInVmailU { get; set; }

    public int? OfInCallOfferCount { get; set; }

    public int? OfRdcallCount { get; set; }

    public decimal? OfInWaitingTime { get; set; }

    public decimal? OfInWaitingTimeMax { get; set; }

    public decimal? OfInAbandonTime { get; set; }

    public decimal? OfInAbandonTimeMax { get; set; }

    public int? InTransCount { get; set; }

    public int? OfRdEmail { get; set; }

    public int? OfRdFax { get; set; }

    public int? OfRdSms { get; set; }

    public int? OfRdWebCall { get; set; }

    public int? OfRdWebChat { get; set; }

    public int? OfRdVmail { get; set; }

    public int OutTranVmail { get; set; }

    public int MediaInBlogU { get; set; }

    public int? OfRdBlogIn { get; set; }
}
