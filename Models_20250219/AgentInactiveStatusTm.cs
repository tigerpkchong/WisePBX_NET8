using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AgentInactiveStatusTm
{
    public int Sid { get; set; }

    public int AgentId { get; set; }

    public int Status { get; set; }

    public int Duration { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}
