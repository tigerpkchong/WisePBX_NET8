using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class DefHoliday
{
    public int Id { get; set; }

    public DateTime? Holiday { get; set; }

    public string? HolTyp { get; set; }

    public string? Description { get; set; }

    public string? UpdateDate { get; set; }

    public string? User { get; set; }
}
