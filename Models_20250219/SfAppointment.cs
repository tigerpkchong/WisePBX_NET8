using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class SfAppointment
{
    public int ApptId { get; set; }

    public string? ParentCaseId { get; set; }

    public bool? IsUch { get; set; }

    public string? ApptSpec { get; set; }

    public string? ApptSubSpec { get; set; }

    public DateOnly? ApptDate { get; set; }

    public string? ApptNewSub { get; set; }

    public string? NonHospital { get; set; }

    public bool? ApptKeep { get; set; }
}
