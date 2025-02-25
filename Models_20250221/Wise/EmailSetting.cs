using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class EmailSetting
{
    public string ProjectName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string EmailType { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Title { get; set; }

    public string? Remarks { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public string? Valid { get; set; }
}
