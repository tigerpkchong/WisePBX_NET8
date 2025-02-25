using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class ResTimeZoneCfg
{
    public int WdId { get; set; }

    public string WdDesc { get; set; } = null!;

    public int BEnable { get; set; }

    public int FromHour { get; set; }

    public int FromMin { get; set; }

    public int ToHour { get; set; }

    public int ToMin { get; set; }
}
