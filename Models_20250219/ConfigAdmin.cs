using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class ConfigAdmin
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public string? Value { get; set; }

    public string? PreSetValue { get; set; }

    public DateTime? EnableTimeStamp { get; set; }

    public DateTime? DisableTimeStamp { get; set; }

    public DateTime? LastUpdateTime { get; set; }

    public int? LastUpdateBy { get; set; }
}
