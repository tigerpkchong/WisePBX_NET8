using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class OfficeHour
{
    public int Id { get; set; }

    public int? StartTime { get; set; }

    public int? EndTime { get; set; }

    public string? WeekDay { get; set; }
}
