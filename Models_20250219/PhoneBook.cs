using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class PhoneBook
{
    public long Pid { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public int PhoneType { get; set; }
}
