using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class CallStatus
{
    public int CallId { get; set; }

    public int Status { get; set; }

    public DateTime TimeStamp { get; set; }
}
