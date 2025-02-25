using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class VwAgentsInCall
{
    public int CallId { get; set; }

    public string? AgentList { get; set; }
}
