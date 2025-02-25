using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class ConnectionStatus
{
    public int ConnId { get; set; }

    public int Status { get; set; }

    public DateTime TimeStamp { get; set; }
}
