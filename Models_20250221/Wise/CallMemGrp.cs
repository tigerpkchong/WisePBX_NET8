using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class CallMemGrp
{
    public long UID { get; set; }

    public int AppTypeID { get; set; }

    public int CallID { get; set; }

    public int DeviceType { get; set; }

    public int DeviceID { get; set; }

    public string? DeviceName { get; set; }

    public string? DeviceRunName { get; set; }
}
