using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class MediaCall_Action_Log
{
    public int Id { get; set; }

    public int? CallId { get; set; }

    public int? AgentId { get; set; }

    public string? Action { get; set; }

    public string? Project { get; set; }

    public int? Updated_By { get; set; }

    public DateTime? Updated_Time { get; set; }
}
