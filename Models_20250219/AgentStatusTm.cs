using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AgentStatusTm
{
    public int Sid { get; set; }

    public int AgentId { get; set; }

    public int Status { get; set; }

    public int? Duration { get; set; }

    public int? Talktype { get; set; }

    public DateTime TimeStamp { get; set; }
}
