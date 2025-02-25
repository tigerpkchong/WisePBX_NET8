using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class Service_Report
{
    public string? ServiceName { get; set; }

    public string ServiceID { get; set; } = null!;

    public string? IsVaild { get; set; }

    public int? Sort { get; set; }
}
