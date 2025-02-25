using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptAcdtime
{
    public int RecordId { get; set; }

    public int Acdid { get; set; }

    public DateTime TimeStamp { get; set; }

    public DateTime WriteDbtime { get; set; }

    public int InCallOfferCount { get; set; }

    public int InCallQueueCount { get; set; }

    public int InCallOfferCountBfwd { get; set; }

    public int OutCallCount { get; set; }

    public int OutCallCountBfwd { get; set; }

    public int PdcallCount { get; set; }

    public int PdcallCountBfwd { get; set; }

    public int TransferCallCount { get; set; }

    public int AbandonCallCount { get; set; }

    public int AbanCallAfterThresCount { get; set; }

    public int AbanThreshold { get; set; }

    public int LoginAgentCount { get; set; }

    public int InCallAnsNoWaitCount { get; set; }

    public int InCallAnsSla01count { get; set; }

    public int InCallAnsSla02count { get; set; }

    public int InCallAnsSla03count { get; set; }

    public int InCallAnsOthersCount { get; set; }

    public int InCallAnsCountBfwd { get; set; }

    public int Sla01 { get; set; }

    public int Sla02 { get; set; }

    public int Sla03 { get; set; }

    public int OutNoAnsCallCount { get; set; }

    public int OutBusyCallCount { get; set; }

    public int OutFailCallCount { get; set; }

    public int OutTalkCallCount { get; set; }

    public int InTransCount { get; set; }

    public int OutTransCount { get; set; }

    public int InInterCount { get; set; }

    public int OutInterCount { get; set; }

    public int InterCallCountBfwd { get; set; }

    public int OtherCallCountBfwd { get; set; }

    public decimal ReadyTime { get; set; }

    public decimal ReadyTimeMax { get; set; }

    public decimal BreakTime { get; set; }

    public decimal BreakTimeMax { get; set; }

    public decimal InTalkTime { get; set; }

    public decimal InTalkTimeMax { get; set; }

    public decimal OutTalkTime { get; set; }

    public decimal OutTalkTimeMax { get; set; }

    public decimal InterTalkTime { get; set; }

    public decimal InterTalkTimeMax { get; set; }

    public decimal OtherTalkTime { get; set; }

    public decimal OtherTalkTimeMax { get; set; }

    public decimal InWaitingTime { get; set; }

    public decimal InWaitingTimeMax { get; set; }

    public decimal InAbandonTime { get; set; }

    public decimal InAbandonTimeMax { get; set; }

    public decimal OutDialingTime { get; set; }

    public decimal LoginAgentTime { get; set; }

    public int MediaInEmailH { get; set; }

    public int MediaInEmailU { get; set; }

    public int MediaInFaxH { get; set; }

    public int MediaInFaxU { get; set; }

    public int MediaInSmsH { get; set; }

    public int MediaInSmsU { get; set; }

    public int MediaInWebCallH { get; set; }

    public int MediaInWebCallU { get; set; }

    public int MediaInWebChatH { get; set; }

    public int MediaInWebChatU { get; set; }

    public int MediaInVmailH { get; set; }

    public int MediaInVmailU { get; set; }

    public int MediaOutEmail { get; set; }

    public int MediaOutFax { get; set; }

    public int MediaOutSms { get; set; }

    public int? ReadyCount { get; set; }

    public int? IdleCount { get; set; }

    public int? BreakCount { get; set; }

    public int? WorkCount { get; set; }

    public int? TalkCount { get; set; }

    public decimal? IdleTime { get; set; }

    public decimal? IdleTimeMax { get; set; }

    public decimal? WorkTime { get; set; }

    public decimal? WorkTimeMax { get; set; }

    public decimal InRecvTime { get; set; }

    public decimal InRecvTimeMax { get; set; }

    public int AbanByDevice { get; set; }

    public int OfInCallOfferCount { get; set; }

    public decimal OfInRecvTime { get; set; }

    public decimal OfInRecvTimeMax { get; set; }

    public decimal OfInWaitingTime { get; set; }

    public decimal OfInWaitingTimeMax { get; set; }

    public decimal OfInAbandonTime { get; set; }

    public decimal OfInAbandonTimeMax { get; set; }

    public int OfAbanByDevice { get; set; }

    public int? OfRdcallCount { get; set; }

    public int? OfRdEmail { get; set; }

    public int? OfRdFax { get; set; }

    public int? OfRdSms { get; set; }

    public int? OfRdWebCall { get; set; }

    public int? OfRdWebChat { get; set; }

    public int? OfRdVmail { get; set; }

    public int OutTranVmail { get; set; }

    public int MediaOutBlog { get; set; }

    public int MediaInBlogU { get; set; }

    public int MediaInBlogH { get; set; }

    public int? OfRdBlogIn { get; set; }

    public decimal TotWorkTime { get; set; }

    public decimal TotWorkTimeMax { get; set; }
}
