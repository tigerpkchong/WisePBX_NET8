using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MonitorAgentSocialMedium
{
    public int? AgentId { get; set; }

    public int? TargetAgentId { get; set; }

    public long? TicketId { get; set; }

    public int? Status { get; set; }

    public DateTime? Timestamp { get; set; }
}
