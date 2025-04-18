﻿using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class Voicemail
{
    public int CallID { get; set; }

    public string Filepath { get; set; } = null!;

    public DateTime Time_stamp { get; set; }

    public string? TelNo { get; set; }

    public string? BackupLabel { get; set; }

    public int? BackupDevice { get; set; }

    public int? BackupEngine { get; set; }

    public DateTime? BackupDate { get; set; }

    public int? PurgeFlag { get; set; }

    public string? ZipFileFolder { get; set; }

    public string? RestoreKey { get; set; }

    public string? ZipPassword { get; set; }

    public byte? CopyToTempFolder { get; set; }

    public int? VMDuration { get; set; }
}
