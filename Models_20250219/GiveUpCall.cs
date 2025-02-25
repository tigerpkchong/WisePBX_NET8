using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class GiveUpCall
{
    public int Connid { get; set; }

    public string? Ani { get; set; }

    public DateTime? TimeStamp { get; set; }
}
