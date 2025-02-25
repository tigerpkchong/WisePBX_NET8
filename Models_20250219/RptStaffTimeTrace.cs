using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class RptStaffTimeTrace
{
    public int Uid { get; set; }

    public DateTime Timestamp { get; set; }

    public int FieldIndex { get; set; }

    public int ValueChanged { get; set; }

    public int CallId { get; set; }
}
