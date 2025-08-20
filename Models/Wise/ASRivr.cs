using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class ASRivr
{
    public int? callID { get; set; }

    public string? result { get; set; }

    public DateTime? timestamp { get; set; }
}
