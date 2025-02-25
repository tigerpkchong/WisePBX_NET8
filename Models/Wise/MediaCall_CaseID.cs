using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class MediaCall_CaseID
{
    public int CaseId { get; set; }

    public int? AgentId { get; set; }

    public string? Remark { get; set; }

    public DateTime? TimeStamp { get; set; }
}
