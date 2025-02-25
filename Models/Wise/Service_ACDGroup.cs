using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class Service_ACDGroup
{
    public int ServiceID { get; set; }

    public int ACDGroupID { get; set; }

    public string? ACDGroupType { get; set; }
}
