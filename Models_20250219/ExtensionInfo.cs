using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class ExtensionInfo
{
    public string Company { get; set; } = null!;

    public int Extension { get; set; }

    public int? AgentId { get; set; }

    public string? LoginId { get; set; }
}
