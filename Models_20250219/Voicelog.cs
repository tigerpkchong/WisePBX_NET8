﻿using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class Voicelog
{
    public int CallId { get; set; }

    public int SerialId { get; set; }

    public string Filepath { get; set; } = null!;

    public DateTime TimeStamp { get; set; }

    public string? BackupLabel { get; set; }

    public int? BackupDevice { get; set; }

    public int? BackupEngine { get; set; }

    public DateTime? BackupDate { get; set; }

    public int? PurgeFlag { get; set; }

    public string? ZipFileFolder { get; set; }

    public string? RestoreKey { get; set; }

    public string? ZipPassword { get; set; }

    public byte? CopyToTempFolder { get; set; }

    public int? FileSize { get; set; }

    public string? AgentName { get; set; }

    public string? Content { get; set; }
}
