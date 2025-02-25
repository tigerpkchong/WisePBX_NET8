using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class DefKeypress
{
    public int NodeId { get; set; }

    public string KeyIndex { get; set; } = null!;

    public string KeypressDesc { get; set; } = null!;
}
