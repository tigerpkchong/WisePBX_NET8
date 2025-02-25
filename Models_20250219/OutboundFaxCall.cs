using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class OutboundFaxCall
{
    public int Id { get; set; }

    public int CallId { get; set; }

    public string Ani { get; set; } = null!;

    public string Dnis { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int TalkTime { get; set; }

    public int Status { get; set; }
}
