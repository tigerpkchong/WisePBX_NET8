using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class WebChat
{
    public int Id { get; set; }

    public string FromNo { get; set; } = null!;

    public string? ToNo { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public int? Status { get; set; }

    public string? TicketId { get; set; }
}
