using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class AgentDirectLine
{
    public int AgentId { get; set; }

    public string? Extension { get; set; }
}
