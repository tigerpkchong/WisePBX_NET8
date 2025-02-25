using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class CallMemGrp
{
    public long Uid { get; set; }

    public int AppTypeId { get; set; }

    public int CallId { get; set; }

    public int DeviceType { get; set; }

    public int DeviceId { get; set; }

    public string? DeviceName { get; set; }

    public string? DeviceRunName { get; set; }
}
