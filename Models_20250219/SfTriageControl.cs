using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class SfTriageControl
{
    public string ClinicSpecialty { get; set; } = null!;

    public bool? ToTriageNurse { get; set; }

    public bool? ToClinicNurse { get; set; }

    public bool? ToClinicDoctor { get; set; }
}
