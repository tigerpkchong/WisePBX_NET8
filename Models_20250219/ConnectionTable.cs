using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class ConnectionTable
{
    public int ConnId { get; set; }

    public int CallId { get; set; }

    public int? Devicetype { get; set; }

    public int? Devicegroup { get; set; }

    public int? DeviceId { get; set; }

    public DateTime? Begintime { get; set; }

    public DateTime Endtime { get; set; }
}
