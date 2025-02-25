using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class SfCase
{
    public int CaseId { get; set; }

    public DateTime? CreationDateTime { get; set; }

    public string? CreatedById { get; set; }

    public string? CreatedByName { get; set; }

    public string? CaseStatus { get; set; }

    public string? DocNumOfDay { get; set; }

    public string? DocOriginalPath { get; set; }

    public string? DocWithCodePath { get; set; }

    public string? PatientHkid { get; set; }

    public string? PatientName { get; set; }

    public string? PatientAge { get; set; }

    public string? PatientGender { get; set; }

    public string? PatientSopd { get; set; }

    public string? PatientMrn { get; set; }

    public string? ReferSpecialty { get; set; }

    public bool? IsOnsite { get; set; }

    public string? NurseSpec { get; set; }

    public string? NurseSubSpec { get; set; }

    public string? NurseCategory { get; set; }

    public int? NurseNumOfWeek { get; set; }

    public DateOnly? NurseSelectedDate { get; set; }

    public string? NurseInfo { get; set; }

    public string? NurseDesignedSpec { get; set; }

    public string? DrSpec { get; set; }

    public string? DrSubSpec { get; set; }

    public string? DrCategory { get; set; }

    public DateOnly? DrDesignedDate { get; set; }

    public int? DrNumOfWeek { get; set; }

    public string? DrInfo { get; set; }
}
