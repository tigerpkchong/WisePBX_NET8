using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models;

public partial class MediaCall
{
    public int CallId { get; set; }

    public int CallType { get; set; }

    public int ServiceId { get; set; }

    public string? Ani { get; set; }

    public string? Dnis { get; set; }

    public string? Sender { get; set; }

    public string? SendTo { get; set; }

    public string? Cc { get; set; }

    public string? Bcc { get; set; }

    public int? PrevCallId { get; set; }

    public string? Subject { get; set; }

    public string? Filename { get; set; }

    public string? IvrsData { get; set; }

    public int ResultId { get; set; }

    public int? AcdgroupId { get; set; }

    public int? AgentId { get; set; }

    public int? IvrsId { get; set; }

    public int? PriorityId { get; set; }

    public DateTime? ArriveDateTime { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ReadDateTime { get; set; }

    public byte? ReadFlag { get; set; }

    public int? CaseId { get; set; }

    public string? FaxHandle { get; set; }

    public int? Pages { get; set; }

    public byte? IsCoverPage { get; set; }

    public DateTime? HandleDateTime { get; set; }

    public byte IsHandleFinish { get; set; }

    public string? HandledNo { get; set; }

    public string? BackupLabel { get; set; }

    public int? BackupDevice { get; set; }

    public int? BackupEngine { get; set; }

    public DateTime? BackupDate { get; set; }

    public int? PurgeFlag { get; set; }

    public string? ZipFileFolder { get; set; }

    public string? RestoreKey { get; set; }

    public string? ZipPassword { get; set; }

    public byte? CopyToTempFolder { get; set; }

    public int? MediaDuration { get; set; }
}
