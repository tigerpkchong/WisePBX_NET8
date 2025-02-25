using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class EmailInbound20250108
{
    public int EmailId { get; set; }

    public string MessageId { get; set; } = null!;

    public int? UnixTimeSeconds { get; set; }

    public DateTime? RecievedDatetime { get; set; }

    public DateTime? EmailDate { get; set; }

    public string? EmailFrom { get; set; }

    public string? Dnis { get; set; }

    public string? EmailCc { get; set; }

    public string? EmailBcc { get; set; }

    public string? EmailSubject { get; set; }

    public string? Filename { get; set; }

    public bool? IsFinish { get; set; }
}
