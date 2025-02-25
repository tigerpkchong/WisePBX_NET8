using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MediaCallActionLog
{
    public int Id { get; set; }

    public int? CallId { get; set; }

    public int? AgentId { get; set; }

    public string? Action { get; set; }

    public string? Project { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedTime { get; set; }
}
