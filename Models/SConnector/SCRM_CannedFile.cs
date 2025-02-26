﻿using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.SConnector;

public partial class SCRM_CannedFile
{
    public string? CompanyName { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public string? FileUrl { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedTime { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdateTime { get; set; }

    public bool? Active { get; set; }

    public int FileId { get; set; }
}
