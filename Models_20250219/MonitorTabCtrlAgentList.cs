using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorTabCtrlAgentList
{
    public int LayoutId { get; set; }

    public int TabPageId { get; set; }

    public int CtrlId { get; set; }

    public string? ViewAcd { get; set; }

    public string? AgentId { get; set; }

    public string? AgentName { get; set; }

    public string? Status { get; set; }

    public string? StatusTime { get; set; }

    public string? StationName { get; set; }

    public string? InCallCount { get; set; }

    public string? OutCallCount { get; set; }

    public string? OutTalkCount { get; set; }

    public string? InterCount { get; set; }

    public string? OtherTalkCount { get; set; }

    public string? DialTime { get; set; }

    public string? InTalkTime { get; set; }

    public string? OutTalkTime { get; set; }

    public string? InterTalkTime { get; set; }

    public string? TalkTime { get; set; }

    public string? OtherTalkTime { get; set; }

    public string? HoldTime { get; set; }

    public string? BreakTime { get; set; }

    public string? IdleTime { get; set; }

    public string? ReadyTime { get; set; }

    public string? WorkTime { get; set; }

    public string? EmailCount { get; set; }

    public string? FaxCount { get; set; }

    public string? SmsCount { get; set; }

    public string? VmailCount { get; set; }

    public string? WebCallCount { get; set; }

    public string? WebChatCount { get; set; }
}
