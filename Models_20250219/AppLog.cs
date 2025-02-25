using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AppLog
{
    public int LogId { get; set; }

    public string? LogType { get; set; }

    public string? ObjectId { get; set; }

    public string? Details { get; set; }

    public int? AgentId { get; set; }

    public DateTime? TimeStamp { get; set; }
}
