using System;
using System.Collections.Generic;

namespace WisePBX.NET8.Models.Wise;

public partial class MediaCall
{
    public int CallID { get; set; }

    public int CallType { get; set; }

    public int ServiceID { get; set; }

    public string? ANI { get; set; }

    public string? DNIS { get; set; }

    public string? Sender { get; set; }

    public string? SendTo { get; set; }

    public string? CC { get; set; }

    public string? BCC { get; set; }

    public int? PrevCallID { get; set; }

    public string? Subject { get; set; }

    public string? Filename { get; set; }

    public string? IvrsData { get; set; }

    public int ResultID { get; set; }

    public int? ACDGroupID { get; set; }

    public int? AgentID { get; set; }

    public int? IvrsID { get; set; }

    public int? PriorityID { get; set; }

    public DateTime? ArriveDateTime { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ReadDateTime { get; set; }

    public byte? ReadFlag { get; set; }

    public int? CaseID { get; set; }

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
