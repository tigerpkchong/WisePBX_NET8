using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class KeyIn
{
    public int CallId { get; set; }

    public int NodeId { get; set; }

    public int KeypressId { get; set; }

    public string Keypress { get; set; } = null!;

    public DateTime TimeStamp { get; set; }
}
