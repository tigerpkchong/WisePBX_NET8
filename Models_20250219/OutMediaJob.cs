using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class OutMediaJob
{
    public long? CallId { get; set; }

    public int? Type { get; set; }

    public string? JobId { get; set; }

    public string? FromName { get; set; }

    public string? FromAddr { get; set; }

    public string? ToName { get; set; }

    public string? Toaddr { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public string? Attachment { get; set; }

    public string? CoverFile { get; set; }

    public short? Priority { get; set; }

    public short? Status { get; set; }

    public DateTime? SubmitTime { get; set; }

    public DateTime? QueueTime { get; set; }

    public int? Pbxid { get; set; }

    public string? G3tiffFile { get; set; }
}
