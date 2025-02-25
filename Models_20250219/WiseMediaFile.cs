using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class WiseMediaFile
{
    public int Logid { get; set; }

    public int Callid { get; set; }

    public int Calltypeid { get; set; }

    public int? Serialid { get; set; }

    public string? Ani { get; set; }

    public string? Dnis { get; set; }

    public string? Filepath { get; set; }

    public string? Ivrsdata { get; set; }

    public DateTime ArriveDatetime { get; set; }

    public int Talktime { get; set; }

    public string CreateAgent { get; set; } = null!;

    public DateTime CreateDatetime { get; set; }

    public string? BackupFilename { get; set; }

    public DateTime? BackupDatetime { get; set; }
}
