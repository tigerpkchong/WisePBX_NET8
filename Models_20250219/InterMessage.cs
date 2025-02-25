using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class InterMessage
{
    public int Id { get; set; }

    public int Sender { get; set; }

    public int Recipient { get; set; }

    public string? Content { get; set; }

    public DateTime SendTime { get; set; }
}
