using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class Acdoperation
{
    public int? CallId { get; set; }

    public int? ConfigVersion { get; set; }

    public int? Targetdevice { get; set; }

    public int? Performdevice { get; set; }

    public int? Performtime { get; set; }

    public DateTime? TimeStamp { get; set; }
}
