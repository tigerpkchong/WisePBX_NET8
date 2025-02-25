using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AgentStatus
{
    public int Sid { get; set; }

    public int AgentId { get; set; }

    public int Status { get; set; }

    public int Talktype { get; set; }

    public string? Remark { get; set; }

    public DateTime TimeStamp { get; set; }
}
