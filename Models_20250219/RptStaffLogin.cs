using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptStaffLogin
{
    public int RecordId { get; set; }

    public int LoginId { get; set; }

    public int InCallCount { get; set; }

    public int InShortCallCount { get; set; }

    public int OutCallCount { get; set; }

    public int PdcallCount { get; set; }

    public int InTalkCount { get; set; }

    public int OutTalkCount { get; set; }

    public int InterTalkCount { get; set; }

    public int OtherTalkCount { get; set; }

    public int InTransCount { get; set; }

    public int OutTransCount { get; set; }

    public int InInterCount { get; set; }

    public int OutInterCount { get; set; }

    public DateTime LoginTime { get; set; }

    public DateTime LogoutTime { get; set; }

    public decimal OnlineTime { get; set; }

    public int ReadyCount { get; set; }

    public int BreakCount { get; set; }

    public decimal DialTime { get; set; }

    public decimal InTalkTime { get; set; }

    public decimal InTalkTimeMax { get; set; }

    public decimal OutTalkTime { get; set; }

    public decimal OutTalkTimeMax { get; set; }

    public decimal InterTalkTime { get; set; }

    public decimal InterTalkTimeMax { get; set; }

    public decimal OtherTalkTime { get; set; }

    public decimal OtherTalkTimeMax { get; set; }

    public decimal HoldTime { get; set; }

    public decimal HoldTimeMax { get; set; }

    public decimal BreakTime { get; set; }

    public decimal BreakTimeMax { get; set; }

    public decimal IdleTime { get; set; }

    public decimal IdleTimeMax { get; set; }

    public decimal ReadyTime { get; set; }

    public decimal ReadyTimeMax { get; set; }

    public decimal InWorkTime { get; set; }

    public decimal InWorkTimeMax { get; set; }

    public decimal OutWorkTime { get; set; }

    public decimal OutWorkTimeMax { get; set; }

    public decimal InterWorkTime { get; set; }

    public decimal InterWorkTimeMax { get; set; }

    public decimal MediaWorkTime { get; set; }

    public decimal MediaWorkTimeMax { get; set; }

    public decimal OtherWorkTime { get; set; }

    public decimal OtherWorkTimeMax { get; set; }

    public decimal OutCallTime { get; set; }

    public int MediaInEmailH { get; set; }

    public int MediaInFaxH { get; set; }

    public int MediaInSmsH { get; set; }

    public int MediaInWebCallH { get; set; }

    public int MediaInWebChatH { get; set; }

    public int MediaInVmailH { get; set; }

    public int MediaOutEmail { get; set; }

    public int MediaOutFax { get; set; }

    public int MediaOutSms { get; set; }

    public decimal? OtherTime { get; set; }

    public decimal? OtherTimeMax { get; set; }

    public int DirectLineAns { get; set; }

    public int DirectLineAban { get; set; }

    public int OutNoAnsCallCount { get; set; }

    public int OutBusyCallCount { get; set; }

    public int OutFailCallCount { get; set; }

    public int OutTalkCallCount { get; set; }

    public int AbanByDevice { get; set; }

    public int? OfRdEmail { get; set; }

    public int? OfRdFax { get; set; }

    public int? OfRdSms { get; set; }

    public int? OfRdWebCall { get; set; }

    public int? OfRdWebChat { get; set; }

    public int? OfRdVmail { get; set; }

    public int? MediaInEmailU { get; set; }

    public int? MediaInFaxU { get; set; }

    public int? MediaInSmsU { get; set; }

    public int? MediaInWebCallU { get; set; }

    public int? MediaInWebChatU { get; set; }

    public int? MediaInVmailU { get; set; }

    public int OfInCallCount { get; set; }

    public int MediaInBlogU { get; set; }

    public int MediaInBlogH { get; set; }

    public int MediaOutBlog { get; set; }

    public int? OfRdBlogIn { get; set; }
}
