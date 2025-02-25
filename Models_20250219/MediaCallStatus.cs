using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MediaCallStatus
{
    public int CallId { get; set; }

    public string? Project { get; set; }

    public bool? IsInvalid { get; set; }

    public bool? IsJunk { get; set; }

    public bool? IsRead { get; set; }

    public bool? IsInternal { get; set; }

    public bool? IsSendAcknowledgement { get; set; }

    public int? AssignedTo { get; set; }

    public string? HandledCaseNo { get; set; }

    public int? HandledBy { get; set; }

    public DateTime? HandledDateTime { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDateTime { get; set; }

    public string? SupervisorRemarks { get; set; }

    public string? ManagerRemarks { get; set; }
}
