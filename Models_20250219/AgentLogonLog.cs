using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AgentLogonLog
{
    public int AgentId { get; set; }

    public DateTime? LastLogin { get; set; }

    public string? LastStatus { get; set; }

    public DateTime? LastChange { get; set; }
}
