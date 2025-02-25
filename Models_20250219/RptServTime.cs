using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptServTime
{
    public int RecordId { get; set; }

    public int Service { get; set; }

    public DateTime TimeStamp { get; set; }

    public DateTime WriteDbtime { get; set; }

    public int InCallCount { get; set; }

    public int InCallQueueCount { get; set; }

    public int InCallCountBfwd { get; set; }

    public int OutCallCount { get; set; }

    public int OutCallCountBfwd { get; set; }

    public int IvrCallCountTotal { get; set; }

    public int IvrCallOnlyCount { get; set; }

    public int AgentCallCount { get; set; }

    public int TransferCallCount { get; set; }

    public int AbandonCallCount { get; set; }

    public int AbanCallAfterThresCount { get; set; }

    public int AbanThreshold { get; set; }

    public int InCallAnsNoWaitCount { get; set; }

    public int InCallAnsSla01count { get; set; }

    public int InCallAnsSla02count { get; set; }

    public int InCallAnsSla03count { get; set; }

    public int InCallAnsOthersCount { get; set; }

    public int Sla01 { get; set; }

    public int Sla02 { get; set; }

    public int Sla03 { get; set; }

    public int OutNoAnsCallCount { get; set; }

    public int OutBusyCallCount { get; set; }

    public int OutFailCallCount { get; set; }

    public int OutTalkCallCount { get; set; }

    public decimal Ivrstime { get; set; }

    public decimal IvrstimeMax { get; set; }

    public decimal InTalkTime { get; set; }

    public decimal InTalkTimeMax { get; set; }

    public decimal OutTalkTime { get; set; }

    public decimal OutTalkTimeMax { get; set; }

    public decimal InWaitingTime { get; set; }

    public decimal InWaitingTimeMax { get; set; }

    public decimal InAbandonTime { get; set; }

    public decimal InAbandonTimeMax { get; set; }

    public decimal OutDialingTime { get; set; }

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

    public decimal InRecvTime { get; set; }

    public decimal InRecvTimeMax { get; set; }

    public int AbanByDevice { get; set; }

    public decimal OfInWaitingTime { get; set; }

    public decimal OfInWaitingTimeMax { get; set; }

    public decimal OfInAbandonTime { get; set; }

    public decimal OfInAbandonTimeMax { get; set; }

    public decimal OfInRecvTime { get; set; }

    public decimal OfInRecvTimeMax { get; set; }

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
}
