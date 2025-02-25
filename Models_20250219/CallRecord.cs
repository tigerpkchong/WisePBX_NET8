using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class CallRecord
{
    public int CallId { get; set; }

    public int SerialId { get; set; }

    public int? AgentId { get; set; }

    public string? StationNumber { get; set; }

    public string Filepath { get; set; } = null!;

    public DateTime TimeStamp { get; set; }
}
