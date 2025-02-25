using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class DefKey
{
    public int KeyId { get; set; }

    public int? ServiceId { get; set; }

    public string KeyPress { get; set; } = null!;

    public string? KeyPressDesc { get; set; }

    public byte? Visible { get; set; }

    public byte? Deleted { get; set; }
}
