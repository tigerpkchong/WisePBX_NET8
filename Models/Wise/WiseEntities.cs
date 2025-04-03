using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WisePBX.NET8.Models.Wise_SP;

namespace WisePBX.NET8.Models.Wise;

public partial class WiseEntities : DbContext
{
    public WiseEntities(DbContextOptions<WiseEntities> options)
        : base(options)
    {
    }
    public virtual DbSet<ACDGroup> ACDGroups { get; set; }

    public virtual DbSet<ACDGroupMember> ACDGroupMembers { get; set; }

    public virtual DbSet<ACDGroup_Access> ACDGroup_Accesses { get; set; }

    public virtual DbSet<AgentInfo> AgentInfos { get; set; }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<CallMemGrp> CallMemGrps { get; set; }

    public virtual DbSet<EmailSetting> EmailSettings { get; set; }

    public virtual DbSet<EmailSetting_Log> EmailSetting_Logs { get; set; }

    public virtual DbSet<MediaCall> MediaCalls { get; set; }

    public virtual DbSet<MediaCall_Action_Log> MediaCall_Action_Logs { get; set; }

    public virtual DbSet<MediaCall_CaseID> MediaCall_CaseIDs { get; set; }

    public virtual DbSet<Monitor_Statistic> Monitor_Statistics { get; set; }

    public virtual DbSet<OutboundANI> OutboundANIs { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Service_ACDGroup> Service_ACDGroups { get; set; }

    public virtual DbSet<Service_Report> Service_Reports { get; set; }

    public virtual DbSet<VW_FullVoiceLog> VW_FullVoiceLogs { get; set; }

    public virtual DbSet<Voicelog> Voicelogs { get; set; }

    public virtual DbSet<Voicemail> Voicemails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SP_Dashboard_Data_Agent_Result>(entity =>
        {
            entity.HasKey(e => e.agent_id);
        });

        modelBuilder.Entity<SP_Dashboard_Data_Result>(entity =>
        {
            entity.HasKey(e => e.time_stamp);
        });
        
        modelBuilder.Entity<SP_wallboard_count_Result>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<ACDGroup>(entity =>
        {
            entity.HasKey(e => e.AcdGroupID).IsClustered(false);

            entity.ToTable("ACDGroup");

            entity.Property(e => e.AcdGroupID).ValueGeneratedNever();
            entity.Property(e => e.AcdGroupDesc).HasMaxLength(50);
        });

        modelBuilder.Entity<ACDGroupMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ACDGroupMember");

            entity.HasIndex(e => new { e.ACDGroupID, e.AgentID }, "IX_AcdGroupMember").IsUnique();

            entity.HasIndex(e => e.ACDGroupID, "IX_AcdGroupMember_1");
        });

        modelBuilder.Entity<ACDGroup_Access>(entity =>
        {
            entity.HasKey(e => new { e.AgentID, e.AcdGroupID });

            entity.ToTable("ACDGroup_Access");
        });

        modelBuilder.Entity<AgentInfo>(entity =>
        {
            entity.HasKey(e => e.AgentID).IsClustered(false);

            entity.ToTable("AgentInfo");

            entity.HasIndex(e => e.LevelID, "IX_AgentInfo");

            entity.Property(e => e.AgentID).ValueGeneratedNever();
            entity.Property(e => e.AgentName).HasMaxLength(50);
            entity.Property(e => e.Password).HasColumnType("text");
        });

        modelBuilder.Entity<Call>(entity =>
        {
            entity.ToTable("Call");

            entity.HasIndex(e => e.Calltype, "IX_Call");

            entity.HasIndex(e => new { e.Calltype, e.Begintime }, "IX_Call_1");

            entity.HasIndex(e => new { e.Begintime, e.Endtime }, "IX_Call_2");

            entity.HasIndex(e => new { e.ServiceID, e.ResultID, e.dDeviceType, e.Begintime }, "IX_Call_3");

            entity.HasIndex(e => new { e.ServiceID, e.Calltype, e.ResultID, e.Begintime }, "IX_Call_4");

            entity.HasIndex(e => new { e.ServiceID, e.ResultID, e.oDeviceType }, "IX_Call_5");

            entity.HasIndex(e => new { e.ServiceID, e.ResultID, e.Calltype }, "IX_Call_6");

            entity.HasIndex(e => e.NextCallID, "IX_NextCallID");

            entity.Property(e => e.ANI)
                .HasMaxLength(64)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.Begintime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DNIS)
                .HasMaxLength(64)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.Endtime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Self_defineID).HasDefaultValue(0);
        });

        modelBuilder.Entity<CallMemGrp>(entity =>
        {
            entity.HasKey(e => e.UID);

            entity.ToTable("CallMemGrp");

            entity.HasIndex(e => new { e.CallID, e.DeviceType, e.DeviceID, e.DeviceRunName }, "IX_CallMemGrp");

            entity.Property(e => e.DeviceName)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.DeviceRunName)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmailSetting>(entity =>
        {
            entity.HasKey(e => new { e.ProjectName, e.EmailAddress, e.EmailType });

            entity.ToTable("EmailSetting");

            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UpdateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Valid)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("Y");
        });

        modelBuilder.Entity<EmailSetting_Log>(entity =>
        {
            entity.ToTable("EmailSetting_Log");

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.UpdateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Valid)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("Y");
        });

        modelBuilder.Entity<MediaCall>(entity =>
        {
            entity.HasKey(e => e.CallID);

            entity.ToTable("MediaCall");

            entity.HasIndex(e => e.CallType, "IX_MediaCall_CallType");

            entity.HasIndex(e => e.DNIS, "IX_MediaCall_DNIS");

            entity.HasIndex(e => new { e.ArriveDateTime, e.CreateDateTime }, "IX_MediaCall_DateTime");

            entity.HasIndex(e => new { e.ReadDateTime, e.ReadFlag }, "IX_MediaCall_Read");

            entity.HasIndex(e => e.AgentID, "IX_MediaCall_byAgent");

            entity.Property(e => e.CallID).ValueGeneratedNever();
            entity.Property(e => e.ANI).HasMaxLength(64);
            entity.Property(e => e.ArriveDateTime).HasColumnType("datetime");
            entity.Property(e => e.BCC).HasDefaultValue("");
            entity.Property(e => e.BackupDate).HasColumnType("datetime");
            entity.Property(e => e.BackupLabel).HasMaxLength(64);
            entity.Property(e => e.CC).HasDefaultValue("");
            entity.Property(e => e.CaseID).HasDefaultValue(0);
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DNIS).HasMaxLength(64);
            entity.Property(e => e.FaxHandle)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Filename)
                .HasMaxLength(256)
                .HasDefaultValue("");
            entity.Property(e => e.HandleDateTime).HasColumnType("datetime");
            entity.Property(e => e.HandledNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsCoverPage).HasDefaultValue((byte)0);
            entity.Property(e => e.IvrsData)
                .HasMaxLength(256)
                .HasDefaultValue("");
            entity.Property(e => e.Pages).HasDefaultValue(0);
            entity.Property(e => e.PrevCallID).HasDefaultValue(0);
            entity.Property(e => e.PriorityID).HasDefaultValue(0);
            entity.Property(e => e.ReadDateTime).HasColumnType("datetime");
            entity.Property(e => e.ReadFlag).HasDefaultValue((byte)0);
            entity.Property(e => e.RestoreKey).HasMaxLength(255);
            entity.Property(e => e.Sender).HasMaxLength(64);
            entity.Property(e => e.Subject)
                .HasMaxLength(1024)
                .HasDefaultValue("");
            entity.Property(e => e.ZipFileFolder).HasMaxLength(255);
            entity.Property(e => e.ZipPassword).HasMaxLength(255);
        });

        modelBuilder.Entity<MediaCall_Action_Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MediaCall_Assign_Log");

            entity.ToTable("MediaCall_Action_Log");

            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Project)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Updated_Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<MediaCall_CaseID>(entity =>
        {
            entity.HasKey(e => e.CaseId);

            entity.ToTable("MediaCall_CaseID");

            entity.Property(e => e.Remark)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Monitor_Statistic>(entity =>
        {
            entity.HasKey(e => new { e.TimeStamp, e.ServiceID, e.ACDGroupID });

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.ACDGroupType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AbandonedCall).HasDefaultValue(0);
            entity.Property(e => e.AbandonedTime).HasDefaultValue(0);
            entity.Property(e => e.AnsweredCall).HasDefaultValue(0);
            entity.Property(e => e.AnsweredTalkTime).HasDefaultValue(0);
            entity.Property(e => e.AvgAbandonedTime).HasDefaultValue(0);
            entity.Property(e => e.IncomingCall).HasDefaultValue(0);
            entity.Property(e => e.OutboundCall).HasDefaultValue(0);
            entity.Property(e => e.OutboundTalkTime).HasDefaultValue(0);
            entity.Property(e => e.PctAbandonedCall).HasDefaultValue(0);
        });

        modelBuilder.Entity<OutboundANI>(entity =>
        {
            entity.HasKey(e => new { e.ServiceName, e.OutboundType });

            entity.ToTable("OutboundANI");

            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OutboundType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ANI)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceID).IsClustered(false);

            entity.ToTable("Service");

            entity.HasIndex(e => e.Cyc, "IX_Service");

            entity.Property(e => e.ServiceID).ValueGeneratedNever();
            entity.Property(e => e.Cyc).HasDefaultValue(5);
            entity.Property(e => e.ServiceDesc).HasMaxLength(50);
        });

        modelBuilder.Entity<Service_ACDGroup>(entity =>
        {
            entity.HasKey(e => new { e.ServiceID, e.ACDGroupID });

            entity.ToTable("Service_ACDGroup");

            entity.Property(e => e.ACDGroupType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Service_Report>(entity =>
        {
            entity.HasKey(e => e.ServiceID);

            entity.ToTable("Service_Report");

            entity.Property(e => e.ServiceID)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsVaild)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ServiceName).HasMaxLength(200);
        });

        modelBuilder.Entity<VW_FullVoiceLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_FullVoiceLog");
            entity.Property(e => e.ServiceDesc).HasMaxLength(100);
            entity.Property(e => e.ANI).HasMaxLength(64);
            entity.Property(e => e.AgentList)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Begintime).HasColumnType("datetime");
            entity.Property(e => e.CallTypeEx)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DNIS).HasMaxLength(64);
        });

        modelBuilder.Entity<Voicelog>(entity =>
        {
            entity.HasKey(e => new { e.CallID, e.SerialID });

            entity.ToTable("Voicelog");

            entity.HasIndex(e => e.CallID, "IX_Voicelog");

            entity.HasIndex(e => e.Time_stamp, "IX_Voicelog_1");

            entity.Property(e => e.AgentName).HasMaxLength(64);
            entity.Property(e => e.BackupDate).HasColumnType("datetime");
            entity.Property(e => e.BackupLabel).HasMaxLength(64);
            entity.Property(e => e.Content).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FileSize).HasDefaultValue(0);
            entity.Property(e => e.Filepath).HasMaxLength(255);
            entity.Property(e => e.RestoreKey).HasMaxLength(255);
            entity.Property(e => e.Time_stamp).HasColumnType("datetime");
            entity.Property(e => e.ZipFileFolder).HasMaxLength(255);
            entity.Property(e => e.ZipPassword).HasMaxLength(255);
        });

        modelBuilder.Entity<Voicemail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Voicemail");

            entity.HasIndex(e => e.CallID, "IX_Voicemail");

            entity.HasIndex(e => e.Time_stamp, "IX_Voicemail_1");

            entity.Property(e => e.BackupDate).HasColumnType("datetime");
            entity.Property(e => e.BackupLabel).HasMaxLength(64);
            entity.Property(e => e.Filepath).HasMaxLength(255);
            entity.Property(e => e.RestoreKey).HasMaxLength(255);
            entity.Property(e => e.TelNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Time_stamp).HasColumnType("datetime");
            entity.Property(e => e.ZipFileFolder).HasMaxLength(255);
            entity.Property(e => e.ZipPassword).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
