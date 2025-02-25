using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AgentStatusFusionBank
{
    public string? HotlineNo { get; set; }

    public string? CallerNo { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? CallId { get; set; }

    public string? AgentId { get; set; }

    public string? AgentStatus { get; set; }

    public string? EventType { get; set; }
}
