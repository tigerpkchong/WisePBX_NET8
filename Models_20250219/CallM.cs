using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class CallM
{
    public long Uid { get; set; }

    public int MscallId { get; set; }

    public int CallId { get; set; }

    public int MscallType { get; set; }

    public int Lmscid { get; set; }

    public DateTime Begintime { get; set; }
}
