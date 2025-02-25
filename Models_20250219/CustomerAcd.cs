using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class CustomerAcd
{
    public int CustomerId { get; set; }

    public string? Phone { get; set; }

    public int? AcdgroupId { get; set; }
}
