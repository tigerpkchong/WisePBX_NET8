using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class OutMail
{
    public int Id { get; set; }

    public string FromAddr { get; set; } = null!;

    public string ToAddr { get; set; } = null!;

    public string? Cc { get; set; }

    public string? Bcc { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public string? Attachment { get; set; }

    public byte Status { get; set; }

    public int BodyType { get; set; }
}
