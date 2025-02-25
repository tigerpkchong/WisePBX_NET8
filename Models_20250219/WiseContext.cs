using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WisePBX.NET8.Models;

public partial class WiseContext : DbContext
{
    public WiseContext()
    {
    }

    public WiseContext(DbContextOptions<WiseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acdconfig> Acdconfigs { get; set; }

    public virtual DbSet<Acdgroup> Acdgroups { get; set; }

    public virtual DbSet<AcdgroupAccess> AcdgroupAccesses { get; set; }

    public virtual DbSet<AcdgroupMember> AcdgroupMembers { get; set; }

    public virtual DbSet<Acdoperation> Acdoperations { get; set; }

    public virtual DbSet<Acdpark> Acdparks { get; set; }

    public virtual DbSet<AgentDirectLine> AgentDirectLines { get; set; }

    public virtual DbSet<AgentEvaluate> AgentEvaluates { get; set; }

    public virtual DbSet<AgentInactiveStatusTm> AgentInactiveStatusTms { get; set; }

    public virtual DbSet<AgentInfo> AgentInfos { get; set; }

    public virtual DbSet<AgentLogonLog> AgentLogonLogs { get; set; }

    public virtual DbSet<AgentStatus> AgentStatuses { get; set; }

    public virtual DbSet<AgentStatusFusionBank> AgentStatusFusionBanks { get; set; }

    public virtual DbSet<AgentStatusTm> AgentStatusTms { get; set; }

    public virtual DbSet<AgentStatusTmBackup> AgentStatusTmBackups { get; set; }

    public virtual DbSet<AgentUsage> AgentUsages { get; set; }

    public virtual DbSet<AgentWork> AgentWorks { get; set; }

    public virtual DbSet<AppLog> AppLogs { get; set; }

    public virtual DbSet<Asrivr> Asrivrs { get; set; }

    public virtual DbSet<BlackTelList> BlackTelLists { get; set; }

    public virtual DbSet<BlogInfo> BlogInfos { get; set; }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<CallBackup> CallBackups { get; set; }

    public virtual DbSet<CallBackupTemp> CallBackupTemps { get; set; }

    public virtual DbSet<CallFee> CallFees { get; set; }

    public virtual DbSet<CallM> CallMs { get; set; }

    public virtual DbSet<CallMemGrp> CallMemGrps { get; set; }

    public virtual DbSet<CallRecord> CallRecords { get; set; }

    public virtual DbSet<CallSkill> CallSkills { get; set; }

    public virtual DbSet<CallStatus> CallStatuses { get; set; }

    public virtual DbSet<Campaign> Campaigns { get; set; }

    public virtual DbSet<CampaignMapping> CampaignMappings { get; set; }

    public virtual DbSet<CampaignStatus> CampaignStatuses { get; set; }

    public virtual DbSet<Chinafwd> Chinafwds { get; set; }

    public virtual DbSet<ConfigAdmin> ConfigAdmins { get; set; }

    public virtual DbSet<ConfigAdminWellcomeMp> ConfigAdminWellcomeMps { get; set; }

    public virtual DbSet<ConnectionStatus> ConnectionStatuses { get; set; }

    public virtual DbSet<ConnectionTable> ConnectionTables { get; set; }

    public virtual DbSet<CustomerAcd> CustomerAcds { get; set; }

    public virtual DbSet<DefHoliday> DefHolidays { get; set; }

    public virtual DbSet<DefKey> DefKeys { get; set; }

    public virtual DbSet<DefKeypress> DefKeypresses { get; set; }

    public virtual DbSet<DocumentForm> DocumentForms { get; set; }

    public virtual DbSet<DropCallRatio> DropCallRatios { get; set; }

    public virtual DbSet<EmailInbound> EmailInbounds { get; set; }

    public virtual DbSet<EmailInbound20250108> EmailInbound20250108s { get; set; }

    public virtual DbSet<EmailOauth> EmailOauths { get; set; }

    public virtual DbSet<EmailSetting> EmailSettings { get; set; }

    public virtual DbSet<EmailSettingLog> EmailSettingLogs { get; set; }

    public virtual DbSet<ExtensionInfo> ExtensionInfos { get; set; }

    public virtual DbSet<GiveUpCall> GiveUpCalls { get; set; }

    public virtual DbSet<InfoAgstatus> InfoAgstatuses { get; set; }

    public virtual DbSet<InfoCallStatus> InfoCallStatuses { get; set; }

    public virtual DbSet<InfoCallType> InfoCallTypes { get; set; }

    public virtual DbSet<InfoDevice> InfoDevices { get; set; }

    public virtual DbSet<InterMessage> InterMessages { get; set; }

    public virtual DbSet<KeyIn> KeyIns { get; set; }

    public virtual DbSet<LicenseUsage> LicenseUsages { get; set; }

    public virtual DbSet<LineGroup> LineGroups { get; set; }

    public virtual DbSet<MediaCall> MediaCalls { get; set; }

    public virtual DbSet<MediaCallActionLog> MediaCallActionLogs { get; set; }

    public virtual DbSet<MediaCallCaseId> MediaCallCaseIds { get; set; }

    public virtual DbSet<MediaCallStatus> MediaCallStatuses { get; set; }

    public virtual DbSet<MediaCallStatusLog> MediaCallStatusLogs { get; set; }

    public virtual DbSet<MonitorAgent> MonitorAgents { get; set; }

    public virtual DbSet<MonitorAgentConfig> MonitorAgentConfigs { get; set; }

    public virtual DbSet<MonitorAgentRole> MonitorAgentRoles { get; set; }

    public virtual DbSet<MonitorAgentSocialMedium> MonitorAgentSocialMedia { get; set; }

    public virtual DbSet<MonitorConfigDatum> MonitorConfigData { get; set; }

    public virtual DbSet<MonitorConfigIcon> MonitorConfigIcons { get; set; }

    public virtual DbSet<MonitorConfigLayout> MonitorConfigLayouts { get; set; }

    public virtual DbSet<MonitorConfigLine> MonitorConfigLines { get; set; }

    public virtual DbSet<MonitorConfigRest> MonitorConfigRests { get; set; }

    public virtual DbSet<MonitorConfigScheme> MonitorConfigSchemes { get; set; }

    public virtual DbSet<MonitorConfigSchemeNode> MonitorConfigSchemeNodes { get; set; }

    public virtual DbSet<MonitorConfigTabCtrl> MonitorConfigTabCtrls { get; set; }

    public virtual DbSet<MonitorConfigTabPage> MonitorConfigTabPages { get; set; }

    public virtual DbSet<MonitorConsoleUser> MonitorConsoleUsers { get; set; }

    public virtual DbSet<MonitorDictionary> MonitorDictionaries { get; set; }

    public virtual DbSet<MonitorMsdbcfg> MonitorMsdbcfgs { get; set; }

    public virtual DbSet<MonitorService> MonitorServices { get; set; }

    public virtual DbSet<MonitorStatistic> MonitorStatistics { get; set; }

    public virtual DbSet<MonitorStatistics20200318> MonitorStatistics20200318s { get; set; }

    public virtual DbSet<MonitorStyleDataGrid> MonitorStyleDataGrids { get; set; }

    public virtual DbSet<MonitorSupervisor> MonitorSupervisors { get; set; }

    public virtual DbSet<MonitorTabCtrlAgentList> MonitorTabCtrlAgentLists { get; set; }

    public virtual DbSet<MonitorTerminal> MonitorTerminals { get; set; }

    public virtual DbSet<MonitorTranLog> MonitorTranLogs { get; set; }

    public virtual DbSet<MonitorWisePlatform> MonitorWisePlatforms { get; set; }

    public virtual DbSet<OfficeHour> OfficeHours { get; set; }

    public virtual DbSet<OutBlog> OutBlogs { get; set; }

    public virtual DbSet<OutMail> OutMails { get; set; }

    public virtual DbSet<OutMediaJob> OutMediaJobs { get; set; }

    public virtual DbSet<OutboundAni> OutboundAnis { get; set; }

    public virtual DbSet<OutboundFaxCall> OutboundFaxCalls { get; set; }

    public virtual DbSet<Pbxconfig> Pbxconfigs { get; set; }

    public virtual DbSet<PdexpIvrkeyFilter> PdexpIvrkeyFilters { get; set; }

    public virtual DbSet<PdexpResFilter> PdexpResFilters { get; set; }

    public virtual DbSet<PhoneBook> PhoneBooks { get; set; }

    public virtual DbSet<PhoneBookType> PhoneBookTypes { get; set; }

    public virtual DbSet<PredictiveDialOutLog> PredictiveDialOutLogs { get; set; }

    public virtual DbSet<PredictiveList> PredictiveLists { get; set; }

    public virtual DbSet<PredictiveLog> PredictiveLogs { get; set; }

    public virtual DbSet<ReadyTime> ReadyTimes { get; set; }

    public virtual DbSet<ResTimeZoneCfg> ResTimeZoneCfgs { get; set; }

    public virtual DbSet<ReturnList> ReturnLists { get; set; }

    public virtual DbSet<RptAcdex> RptAcdices { get; set; }

    public virtual DbSet<RptAcdgroup> RptAcdgroups { get; set; }

    public virtual DbSet<RptAcdtime> RptAcdtimes { get; set; }

    public virtual DbSet<RptAcdtimeNew> RptAcdtimeNews { get; set; }

    public virtual DbSet<RptAcdtrace> RptAcdtraces { get; set; }

    public virtual DbSet<RptAgent> RptAgents { get; set; }

    public virtual DbSet<RptAgentEx> RptAgentExes { get; set; }

    public virtual DbSet<RptAgentLogin> RptAgentLogins { get; set; }

    public virtual DbSet<RptAgentTimeNew> RptAgentTimeNews { get; set; }

    public virtual DbSet<RptIvrshourly> RptIvrshourlies { get; set; }

    public virtual DbSet<RptMediaService> RptMediaServices { get; set; }

    public virtual DbSet<RptParkTime> RptParkTimes { get; set; }

    public virtual DbSet<RptParkTrace> RptParkTraces { get; set; }

    public virtual DbSet<RptPool> RptPools { get; set; }

    public virtual DbSet<RptServEx> RptServExes { get; set; }

    public virtual DbSet<RptServTime> RptServTimes { get; set; }

    public virtual DbSet<RptServTrace> RptServTraces { get; set; }

    public virtual DbSet<RptServiceIn> RptServiceIns { get; set; }

    public virtual DbSet<RptServiceOut> RptServiceOuts { get; set; }

    public virtual DbSet<RptServiceTimeNew> RptServiceTimeNews { get; set; }

    public virtual DbSet<RptStaffLogin> RptStaffLogins { get; set; }

    public virtual DbSet<RptStaffLoginTrace> RptStaffLoginTraces { get; set; }

    public virtual DbSet<RptStaffTime> RptStaffTimes { get; set; }

    public virtual DbSet<RptStaffTimeTrace> RptStaffTimeTraces { get; set; }

    public virtual DbSet<RptStationTime> RptStationTimes { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceAcdgroup> ServiceAcdgroups { get; set; }

    public virtual DbSet<ServiceReport> ServiceReports { get; set; }

    public virtual DbSet<SfAppointment> SfAppointments { get; set; }

    public virtual DbSet<SfCase> SfCases { get; set; }

    public virtual DbSet<SfTriageControl> SfTriageControls { get; set; }

    public virtual DbSet<SlaChangeLog> SlaChangeLogs { get; set; }

    public virtual DbSet<SocialChat> SocialChats { get; set; }

    public virtual DbSet<SpaceUsage> SpaceUsages { get; set; }

    public virtual DbSet<SpaceUsageTable> SpaceUsageTables { get; set; }

    public virtual DbSet<StationUsage> StationUsages { get; set; }

    public virtual DbSet<TblTimeRange> TblTimeRanges { get; set; }

    public virtual DbSet<TrunkStatus> TrunkStatuses { get; set; }

    public virtual DbSet<TrunkUsage> TrunkUsages { get; set; }

    public virtual DbSet<Videolog> Videologs { get; set; }

    public virtual DbSet<VoiceContent> VoiceContents { get; set; }

    public virtual DbSet<Voicelog> Voicelogs { get; set; }

    public virtual DbSet<Voicemail> Voicemails { get; set; }

    public virtual DbSet<VwAgentsInCall> VwAgentsInCalls { get; set; }

    public virtual DbSet<VwFullVoiceLog> VwFullVoiceLogs { get; set; }

    public virtual DbSet<VwPhonesInCall> VwPhonesInCalls { get; set; }

    public virtual DbSet<VwVoiceLogPath> VwVoiceLogPaths { get; set; }

    public virtual DbSet<WebCall> WebCalls { get; set; }

    public virtual DbSet<WebChat> WebChats { get; set; }

    public virtual DbSet<WebRptType> WebRptTypes { get; set; }

    public virtual DbSet<WiseBlackListPhone> WiseBlackListPhones { get; set; }

    public virtual DbSet<WiseDbChangeLog> WiseDbChangeLogs { get; set; }

    public virtual DbSet<WiseMediaAcd> WiseMediaAcds { get; set; }

    public virtual DbSet<WiseMediaFile> WiseMediaFiles { get; set; }

    public virtual DbSet<WiseWallBoardMcid> WiseWallBoardMcids { get; set; }

    public virtual DbSet<WiseWallBoardParameter> WiseWallBoardParameters { get; set; }

    public virtual DbSet<WiseWallBoardRpt> WiseWallBoardRpts { get; set; }

    public virtual DbSet<WiseWbacdrpt> WiseWbacdrpts { get; set; }

    public virtual DbSet<WorkingTime> WorkingTimes { get; set; }

    public virtual DbSet<SP_Dashboard_Data_Agent_Result> SP_Dashboard_Data_Agent { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=172.17.7.40;Database=Wise;Integrated Security=false;User ID=sa;Password=+Epro_Demo+;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acdconfig>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ACDConfig");

            entity.HasIndex(e => new { e.Acdpark, e.TimeStamp }, "IX_ACDConfig");

            entity.Property(e => e.Acdpark).HasColumnName("ACDPark");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<Acdgroup>(entity =>
        {
            entity.HasKey(e => e.AcdGroupId).IsClustered(false);

            entity.ToTable("ACDGroup");

            entity.Property(e => e.AcdGroupId)
                .ValueGeneratedNever()
                .HasColumnName("AcdGroupID");
            entity.Property(e => e.AcdGroupDesc).HasMaxLength(50);
        });

        modelBuilder.Entity<AcdgroupAccess>(entity =>
        {
            entity.HasKey(e => new { e.AgentId, e.AcdGroupId });

            entity.ToTable("ACDGroup_Access");

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.AcdGroupId).HasColumnName("AcdGroupID");
        });

        modelBuilder.Entity<AcdgroupMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ACDGroupMember");

            entity.HasIndex(e => new { e.AcdgroupId, e.AgentId }, "IX_AcdGroupMember").IsUnique();

            entity.HasIndex(e => e.AcdgroupId, "IX_AcdGroupMember_1");

            entity.Property(e => e.AcdgroupId).HasColumnName("ACDGroupID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
        });

        modelBuilder.Entity<Acdoperation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ACDOperation");

            entity.HasIndex(e => e.CallId, "IX_ACDOperation");

            entity.HasIndex(e => new { e.CallId, e.TimeStamp }, "IX_ACDOperation_1");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<Acdpark>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("ACDPark");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<AgentDirectLine>(entity =>
        {
            entity.HasKey(e => e.AgentId);

            entity.ToTable("agentDirectLine");

            entity.Property(e => e.AgentId)
                .ValueGeneratedNever()
                .HasColumnName("agentID");
            entity.Property(e => e.Extension)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("extension");
        });

        modelBuilder.Entity<AgentEvaluate>(entity =>
        {
            entity.HasKey(e => e.Itemid);

            entity.ToTable("AgentEvaluate");

            entity.Property(e => e.CallBegintime).HasColumnType("datetime");
            entity.Property(e => e.EvaluateDate).HasColumnType("datetime");
            entity.Property(e => e.EvaluateItem0).HasDefaultValue(8);
            entity.Property(e => e.EvaluateItem1).HasDefaultValue(8);
            entity.Property(e => e.EvaluateItem2).HasDefaultValue(8);
            entity.Property(e => e.EvaluateItem3).HasDefaultValue(8);
            entity.Property(e => e.EvaluateItem4).HasDefaultValue(8);
            entity.Property(e => e.EvaluateItem5).HasDefaultValue(8);
            entity.Property(e => e.EvaluateItem6).HasDefaultValue(8);
            entity.Property(e => e.EvaluateItem7).HasDefaultValue(8);
            entity.Property(e => e.EvaluateItem8).HasDefaultValue(8);
            entity.Property(e => e.EvaluateItem9).HasDefaultValue(8);
        });

        modelBuilder.Entity<AgentInactiveStatusTm>(entity =>
        {
            entity.HasKey(e => e.Sid);

            entity.ToTable("AgentInactiveStatusTM");

            entity.Property(e => e.Sid).HasColumnName("SID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<AgentInfo>(entity =>
        {
            entity.HasKey(e => e.AgentId).IsClustered(false);

            entity.ToTable("AgentInfo");

            entity.HasIndex(e => e.LevelId, "IX_AgentInfo");

            entity.Property(e => e.AgentId)
                .ValueGeneratedNever()
                .HasColumnName("AgentID");
            entity.Property(e => e.AgentName).HasMaxLength(50);
            entity.Property(e => e.LevelId).HasColumnName("LevelID");
            entity.Property(e => e.Password).HasColumnType("text");
            entity.Property(e => e.Pdflag).HasColumnName("PDFlag");
        });

        modelBuilder.Entity<AgentLogonLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AgentLogonLog");

            entity.Property(e => e.AgentId).HasColumnName("agentID");
            entity.Property(e => e.LastChange)
                .HasColumnType("datetime")
                .HasColumnName("lastChange");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("lastLogin");
            entity.Property(e => e.LastStatus)
                .HasMaxLength(50)
                .HasColumnName("lastStatus");
        });

        modelBuilder.Entity<AgentStatus>(entity =>
        {
            entity.HasKey(e => e.Sid);

            entity.ToTable("AgentStatus");

            entity.HasIndex(e => new { e.AgentId, e.TimeStamp }, "IX_AgentStatus");

            entity.HasIndex(e => new { e.AgentId, e.Status, e.Talktype, e.TimeStamp }, "IX_AgentStatus_1");

            entity.HasIndex(e => new { e.AgentId, e.Status }, "IX_AgentStatus_2");

            entity.HasIndex(e => new { e.TimeStamp, e.Sid }, "IX_AgentStatus_3");

            entity.HasIndex(e => new { e.Sid, e.AgentId, e.TimeStamp, e.Talktype, e.Status }, "IX_AgentStatus_4");

            entity.Property(e => e.Sid).HasColumnName("SID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Remark).HasMaxLength(50);
            entity.Property(e => e.Talktype).HasDefaultValue(-1);
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<AgentStatusFusionBank>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AgentStatus_FusionBank");

            entity.Property(e => e.AgentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("agentId");
            entity.Property(e => e.AgentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("agentStatus");
            entity.Property(e => e.CallId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("callId");
            entity.Property(e => e.CallerNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("callerNo");
            entity.Property(e => e.EventType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("eventType");
            entity.Property(e => e.HotlineNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<AgentStatusTm>(entity =>
        {
            entity.HasKey(e => e.Sid);

            entity.ToTable("AgentStatusTM");

            entity.HasIndex(e => new { e.AgentId, e.Status, e.Talktype, e.TimeStamp, e.Sid }, "IX_AgentStatusTM");

            entity.HasIndex(e => new { e.TimeStamp, e.AgentId, e.Talktype, e.Status }, "IX_AgentStatusTM_1");

            entity.Property(e => e.Sid).HasColumnName("SID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Talktype).HasDefaultValue(-1);
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<AgentStatusTmBackup>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK_AgentStatusTM_backup");

            entity.ToTable("AgentStatusTM_Backup");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("SID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<AgentUsage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AgentUsage");

            entity.HasIndex(e => new { e.RpDate, e.DeviceType, e.DeviceId }, "IX_AgentUsage");

            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.RpDate)
                .HasColumnType("datetime")
                .HasColumnName("RP_Date");
        });

        modelBuilder.Entity<AgentWork>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AgentWork");

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.BeginTime).HasColumnType("datetime");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<AppLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("appLog");

            entity.Property(e => e.LogId).HasColumnName("logID");
            entity.Property(e => e.AgentId)
                .HasDefaultValue(0)
                .HasColumnName("agentID");
            entity.Property(e => e.Details)
                .HasMaxLength(1000)
                .HasDefaultValue("")
                .HasColumnName("details");
            entity.Property(e => e.LogType)
                .HasMaxLength(100)
                .HasColumnName("logType");
            entity.Property(e => e.ObjectId)
                .HasMaxLength(100)
                .HasColumnName("objectID");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
        });

        modelBuilder.Entity<Asrivr>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ASRivrs");

            entity.HasIndex(e => new { e.CallId, e.Timestamp }, "callID");

            entity.Property(e => e.CallId).HasColumnName("callID");
            entity.Property(e => e.Result)
                .HasColumnType("ntext")
                .HasColumnName("result");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<BlackTelList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BlackTelList");

            entity.HasIndex(e => new { e.CampaignId, e.Telephone }, "IX_BlackTelList");

            entity.HasIndex(e => e.Telephone, "IX_BlackTelList_1");

            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<BlogInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BlogInfo");

            entity.Property(e => e.AccName)
                .HasMaxLength(129)
                .IsUnicode(false);
            entity.Property(e => e.BlogId)
                .HasMaxLength(129)
                .IsUnicode(false)
                .HasColumnName("BlogID");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Call>(entity =>
        {
            entity.ToTable("Call");

            entity.HasIndex(e => e.Calltype, "IX_Call");

            entity.HasIndex(e => new { e.Calltype, e.Begintime }, "IX_Call_1");

            entity.HasIndex(e => new { e.Begintime, e.Endtime }, "IX_Call_2");

            entity.HasIndex(e => new { e.ServiceId, e.ResultId, e.DDeviceType, e.Begintime }, "IX_Call_3");

            entity.HasIndex(e => new { e.ServiceId, e.Calltype, e.ResultId, e.Begintime }, "IX_Call_4");

            entity.HasIndex(e => new { e.ServiceId, e.ResultId, e.ODeviceType }, "IX_Call_5");

            entity.HasIndex(e => new { e.ServiceId, e.ResultId, e.Calltype }, "IX_Call_6");

            entity.HasIndex(e => e.NextCallId, "IX_NextCallID");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Ani)
                .HasMaxLength(64)
                .HasDefaultValueSql("((0))")
                .HasColumnName("ANI");
            entity.Property(e => e.Begintime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CaseId).HasColumnName("CaseID");
            entity.Property(e => e.DDeviceGroup).HasColumnName("dDeviceGroup");
            entity.Property(e => e.DDeviceId).HasColumnName("dDeviceID");
            entity.Property(e => e.DDeviceType).HasColumnName("dDeviceType");
            entity.Property(e => e.Dnis)
                .HasMaxLength(64)
                .HasDefaultValueSql("((0))")
                .HasColumnName("DNIS");
            entity.Property(e => e.Endtime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.HoldCallId).HasColumnName("HoldCallID");
            entity.Property(e => e.NextCallId).HasColumnName("NextCallID");
            entity.Property(e => e.ODeviceGroup).HasColumnName("oDeviceGroup");
            entity.Property(e => e.ODeviceId).HasColumnName("oDeviceID");
            entity.Property(e => e.ODeviceType).HasColumnName("oDeviceType");
            entity.Property(e => e.PrevCallId).HasColumnName("PrevCallID");
            entity.Property(e => e.ResultId).HasColumnName("ResultID");
            entity.Property(e => e.SelfDefineId)
                .HasDefaultValue(0)
                .HasColumnName("Self_defineID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
        });

        modelBuilder.Entity<CallBackup>(entity =>
        {
            entity.HasKey(e => e.CallId);

            entity.ToTable("Call_Backup");

            entity.HasIndex(e => e.Begintime, "IK_Call_Backup_BeginTime");

            entity.HasIndex(e => e.Calltype, "IK_Call_Backup_CallType");

            entity.HasIndex(e => e.ServiceId, "IK_Call_Backup_ServiceID");

            entity.HasIndex(e => e.DDeviceGroup, "IK_Call_Backup_dDeviceGroup");

            entity.Property(e => e.CallId)
                .ValueGeneratedNever()
                .HasColumnName("CallID");
            entity.Property(e => e.Ani)
                .HasMaxLength(64)
                .HasColumnName("ANI");
            entity.Property(e => e.Begintime).HasColumnType("datetime");
            entity.Property(e => e.CaseId).HasColumnName("CaseID");
            entity.Property(e => e.DDeviceGroup).HasColumnName("dDeviceGroup");
            entity.Property(e => e.DDeviceId).HasColumnName("dDeviceID");
            entity.Property(e => e.DDeviceType).HasColumnName("dDeviceType");
            entity.Property(e => e.Dnis)
                .HasMaxLength(64)
                .HasColumnName("DNIS");
            entity.Property(e => e.Endtime).HasColumnType("datetime");
            entity.Property(e => e.HoldCallId).HasColumnName("HoldCallID");
            entity.Property(e => e.NextCallId).HasColumnName("NextCallID");
            entity.Property(e => e.ODeviceGroup).HasColumnName("oDeviceGroup");
            entity.Property(e => e.ODeviceId).HasColumnName("oDeviceID");
            entity.Property(e => e.ODeviceType).HasColumnName("oDeviceType");
            entity.Property(e => e.PrevCallId).HasColumnName("PrevCallID");
            entity.Property(e => e.ResultId).HasColumnName("ResultID");
            entity.Property(e => e.SelfDefineId).HasColumnName("Self_defineID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Vmduration)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("VMDuration");
        });

        modelBuilder.Entity<CallBackupTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("call_backup_temp");

            entity.Property(e => e.Ani)
                .HasMaxLength(64)
                .HasColumnName("ANI");
            entity.Property(e => e.Begintime).HasColumnType("datetime");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.CaseId).HasColumnName("CaseID");
            entity.Property(e => e.DDeviceGroup).HasColumnName("dDeviceGroup");
            entity.Property(e => e.DDeviceId).HasColumnName("dDeviceID");
            entity.Property(e => e.DDeviceType).HasColumnName("dDeviceType");
            entity.Property(e => e.Dnis)
                .HasMaxLength(64)
                .HasColumnName("DNIS");
            entity.Property(e => e.Endtime).HasColumnType("datetime");
            entity.Property(e => e.HoldCallId).HasColumnName("HoldCallID");
            entity.Property(e => e.NextCallId).HasColumnName("NextCallID");
            entity.Property(e => e.ODeviceGroup).HasColumnName("oDeviceGroup");
            entity.Property(e => e.ODeviceId).HasColumnName("oDeviceID");
            entity.Property(e => e.ODeviceType).HasColumnName("oDeviceType");
            entity.Property(e => e.PrevCallId).HasColumnName("PrevCallID");
            entity.Property(e => e.ResultId).HasColumnName("ResultID");
            entity.Property(e => e.SelfDefineId).HasColumnName("Self_defineID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Vmduration).HasColumnName("VMDuration");
        });

        modelBuilder.Entity<CallFee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CallFee");

            entity.Property(e => e.Ani)
                .HasMaxLength(50)
                .HasColumnName("ANI");
            entity.Property(e => e.BeginTime).HasColumnType("datetime");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Dnis)
                .HasMaxLength(50)
                .HasColumnName("DNIS");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.RelatedCallId).HasColumnName("RelatedCallID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
        });

        modelBuilder.Entity<CallM>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("CallMS");

            entity.HasIndex(e => e.CallId, "IX_CallID");

            entity.HasIndex(e => e.Lmscid, "IX_LMSCID");

            entity.HasIndex(e => e.MscallId, "IX_MSCallID");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.Begintime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Lmscid)
                .HasDefaultValue(-1)
                .HasColumnName("LMSCID");
            entity.Property(e => e.MscallId).HasColumnName("MSCallID");
            entity.Property(e => e.MscallType)
                .HasDefaultValue(-1)
                .HasColumnName("MSCallType");
        });

        modelBuilder.Entity<CallMemGrp>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("CallMemGrp");

            entity.HasIndex(e => new { e.CallId, e.DeviceType, e.DeviceId, e.DeviceRunName }, "IX_CallMemGrp");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.AppTypeId).HasColumnName("AppTypeID");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.DeviceRunName)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CallRecord>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CallRecord");

            entity.Property(e => e.AgentId).HasColumnName("agentID");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Filepath)
                .HasMaxLength(255)
                .HasColumnName("filepath");
            entity.Property(e => e.SerialId).HasColumnName("SerialID");
            entity.Property(e => e.StationNumber)
                .HasMaxLength(50)
                .HasColumnName("stationNumber");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<CallSkill>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CallSkill");

            entity.HasIndex(e => e.CallId, "IX_CallSkill");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.SkillId).HasColumnName("SkillID");
        });

        modelBuilder.Entity<CallStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CallStatus");

            entity.HasIndex(e => e.TimeStamp, "IX_CallStatus");

            entity.HasIndex(e => e.CallId, "IX_CallStatus_1");

            entity.HasIndex(e => new { e.Status, e.TimeStamp }, "IX_CallStatus_2");

            entity.HasIndex(e => new { e.CallId, e.Status, e.TimeStamp }, "IX_CallStatus_3");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.ToTable("Campaign");

            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
            entity.Property(e => e.Active).HasDefaultValue(0);
            entity.Property(e => e.Ani)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("ANI");
            entity.Property(e => e.AttemptCount).HasDefaultValue(0);
            entity.Property(e => e.ContactResult)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))");
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.DialOutRatio).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FriEndTime).HasColumnType("datetime");
            entity.Property(e => e.FriStartTime).HasColumnType("datetime");
            entity.Property(e => e.MonEndTime).HasColumnType("datetime");
            entity.Property(e => e.MonStartTime).HasColumnType("datetime");
            entity.Property(e => e.PrefixNumber)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Remark)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SatEndTime).HasColumnType("datetime");
            entity.Property(e => e.SatStartTime).HasColumnType("datetime");
            entity.Property(e => e.ServiceId)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("ServiceID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.SunEndTime).HasColumnType("datetime");
            entity.Property(e => e.SunStartTime).HasColumnType("datetime");
            entity.Property(e => e.TeleFlag1).HasDefaultValue(1);
            entity.Property(e => e.TeleFlag2).HasDefaultValue(0);
            entity.Property(e => e.TeleFlag3).HasDefaultValue(0);
            entity.Property(e => e.TeleFlag4).HasDefaultValue(0);
            entity.Property(e => e.ThuEndTime).HasColumnType("datetime");
            entity.Property(e => e.ThuStartTime).HasColumnType("datetime");
            entity.Property(e => e.TueEndTime).HasColumnType("datetime");
            entity.Property(e => e.TueStartTime).HasColumnType("datetime");
            entity.Property(e => e.WedEndTime).HasColumnType("datetime");
            entity.Property(e => e.WedStartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<CampaignMapping>(entity =>
        {
            entity.HasKey(e => e.Ivrs).HasName("PK__Campaign__453D8CE1875CB5A2");

            entity.ToTable("CampaignMapping");

            entity.Property(e => e.Ivrs)
                .ValueGeneratedNever()
                .HasColumnName("IVRS");
            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
        });

        modelBuilder.Entity<CampaignStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CampaignStatus");

            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
        });

        modelBuilder.Entity<Chinafwd>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("chinafwd");

            entity.Property(e => e.Inno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("inno");
            entity.Property(e => e.Outno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("outno");
        });

        modelBuilder.Entity<ConfigAdmin>(entity =>
        {
            entity.ToTable("ConfigAdmin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DisableTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.EnableTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            entity.Property(e => e.PreSetValue)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConfigAdminWellcomeMp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ConfigAdmin_WellcomeMP");

            entity.Property(e => e.DisableTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.EnableTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");
            entity.Property(e => e.PreSetValue)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ConnectionStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ConnectionStatus");

            entity.HasIndex(e => e.ConnId, "IX_ConnectionStatus");

            entity.HasIndex(e => e.TimeStamp, "IX_ConnectionStatus_1");

            entity.HasIndex(e => e.Status, "IX_ConnectionStatus_2");

            entity.HasIndex(e => new { e.Status, e.TimeStamp }, "IX_ConnectionStatus_3");

            entity.Property(e => e.ConnId).HasColumnName("ConnID");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");
        });

        modelBuilder.Entity<ConnectionTable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ConnectionTable");

            entity.HasIndex(e => e.Begintime, "IX_ConnectionTable");

            entity.HasIndex(e => new { e.CallId, e.Begintime }, "IX_ConnectionTable_1");

            entity.HasIndex(e => e.ConnId, "IX_ConnectionTable_2");

            entity.HasIndex(e => new { e.DeviceId, e.Begintime }, "IX_ConnectionTable_3");

            entity.Property(e => e.Begintime).HasColumnType("datetime");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.ConnId).HasColumnName("ConnID");
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.Endtime).HasColumnType("datetime");
        });

        modelBuilder.Entity<CustomerAcd>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("CustomerACD");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.AcdgroupId).HasColumnName("ACDGroupID");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DefHoliday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PfHoliday");

            entity.ToTable("def_holiday");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.HolTyp).HasMaxLength(1);
            entity.Property(e => e.Holiday)
                .HasColumnType("datetime")
                .HasColumnName("holiday");
            entity.Property(e => e.UpdateDate).HasMaxLength(10);
            entity.Property(e => e.User).HasMaxLength(30);
        });

        modelBuilder.Entity<DefKey>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("defKey");

            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.KeyId)
                .ValueGeneratedOnAdd()
                .HasColumnName("keyID");
            entity.Property(e => e.KeyPress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("keyPress");
            entity.Property(e => e.KeyPressDesc).HasMaxLength(200);
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.Visible).HasColumnName("visible");
        });

        modelBuilder.Entity<DefKeypress>(entity =>
        {
            entity.HasKey(e => new { e.NodeId, e.KeyIndex });

            entity.ToTable("DefKeypress");

            entity.Property(e => e.NodeId).HasColumnName("NodeID");
            entity.Property(e => e.KeyIndex).HasMaxLength(50);
            entity.Property(e => e.KeypressDesc).HasMaxLength(50);
        });

        modelBuilder.Entity<DocumentForm>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("documentForm");

            entity.Property(e => e.ItemId).HasColumnName("itemID");
            entity.Property(e => e.DocumentName)
                .HasMaxLength(50)
                .HasColumnName("documentName");
            entity.Property(e => e.DocumentPath)
                .HasMaxLength(100)
                .HasColumnName("documentPath");
        });

        modelBuilder.Entity<DropCallRatio>(entity =>
        {
            entity.HasKey(e => new { e.StepId, e.CampaignId, e.ConditionId }).HasName("PK_DialOutRatio");

            entity.ToTable("DropCallRatio");

            entity.Property(e => e.StepId).HasColumnName("StepID");
            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
            entity.Property(e => e.ConditionId).HasColumnName("ConditionID");
            entity.Property(e => e.Condition)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Formula)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmailInbound>(entity =>
        {
            entity.HasKey(e => e.EmailId);

            entity.ToTable("Email_Inbound");

            entity.HasIndex(e => e.EmailDate, "IX_Email_Inbound_EmailDate");

            entity.Property(e => e.Dnis)
                .IsUnicode(false)
                .HasColumnName("DNIS");
            entity.Property(e => e.EmailBcc).IsUnicode(false);
            entity.Property(e => e.EmailCc).IsUnicode(false);
            entity.Property(e => e.EmailDate).HasColumnType("datetime");
            entity.Property(e => e.EmailFrom)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EmailSubject).HasMaxLength(1024);
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.MessageId)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.RecievedDatetime).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmailInbound20250108>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Email_Inbound_20250108");

            entity.Property(e => e.Dnis)
                .IsUnicode(false)
                .HasColumnName("DNIS");
            entity.Property(e => e.EmailBcc).IsUnicode(false);
            entity.Property(e => e.EmailCc).IsUnicode(false);
            entity.Property(e => e.EmailDate).HasColumnType("datetime");
            entity.Property(e => e.EmailFrom)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.EmailId).ValueGeneratedOnAdd();
            entity.Property(e => e.EmailSubject).HasMaxLength(1024);
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.MessageId)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.RecievedDatetime).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmailOauth>(entity =>
        {
            entity.HasKey(e => e.Campaign);

            entity.ToTable("Email_OAuth");

            entity.Property(e => e.Campaign)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClientId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("clientId");
            entity.Property(e => e.ClientSecret)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("clientSecret");
            entity.Property(e => e.Emails)
                .IsUnicode(false)
                .HasColumnName("emails");
            entity.Property(e => e.TenantId)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tenantId");
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

        modelBuilder.Entity<EmailSettingLog>(entity =>
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

        modelBuilder.Entity<ExtensionInfo>(entity =>
        {
            entity.HasKey(e => new { e.Company, e.Extension });

            entity.ToTable("ExtensionInfo");

            entity.Property(e => e.Company)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.LoginId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LoginID");
        });

        modelBuilder.Entity<GiveUpCall>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("GiveUpCall");

            entity.Property(e => e.Ani)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");
        });

        modelBuilder.Entity<InfoAgstatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Info_AGStatus");

            entity.HasIndex(e => e.Uid, "IX_ID").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<InfoCallStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Info_CallStatus");

            entity.HasIndex(e => e.Uid, "IX_ID").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<InfoCallType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Info_CallType");

            entity.HasIndex(e => e.Uid, "IX_ID").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<InfoDevice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Info_Device");

            entity.HasIndex(e => e.Uid, "IX_ID").IsUnique();

            entity.Property(e => e.Description)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<InterMessage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("InterMessage");

            entity.Property(e => e.Content).HasMaxLength(500);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.SendTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<KeyIn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("KeyIn");

            entity.HasIndex(e => e.CallId, "IX_KeyIn");

            entity.HasIndex(e => e.TimeStamp, "IX_KeyIn_1");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Keypress).HasMaxLength(20);
            entity.Property(e => e.KeypressId).HasColumnName("KeypressID");
            entity.Property(e => e.NodeId).HasColumnName("NodeID");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");
        });

        modelBuilder.Entity<LicenseUsage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LicenseUsage");

            entity.HasIndex(e => e.RpDate, "IX_Date");

            entity.HasIndex(e => new { e.Ivrs, e.RpDate }, "IX_IVRS_DATE");

            entity.Property(e => e.Ivrs).HasColumnName("IVRS");
            entity.Property(e => e.RpDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("RP_Date");
        });

        modelBuilder.Entity<LineGroup>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("LineGroup");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<MediaCall>(entity =>
        {
            entity.HasKey(e => e.CallId);

            entity.ToTable("MediaCall");

            entity.HasIndex(e => e.CallType, "IX_MediaCall_CallType");

            entity.HasIndex(e => e.Dnis, "IX_MediaCall_DNIS");

            entity.HasIndex(e => new { e.ArriveDateTime, e.CreateDateTime }, "IX_MediaCall_DateTime");

            entity.HasIndex(e => new { e.ReadDateTime, e.ReadFlag }, "IX_MediaCall_Read");

            entity.HasIndex(e => e.AgentId, "IX_MediaCall_byAgent");

            entity.Property(e => e.CallId)
                .ValueGeneratedNever()
                .HasColumnName("CallID");
            entity.Property(e => e.AcdgroupId).HasColumnName("ACDGroupID");
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Ani)
                .HasMaxLength(64)
                .HasColumnName("ANI");
            entity.Property(e => e.ArriveDateTime).HasColumnType("datetime");
            entity.Property(e => e.BackupDate).HasColumnType("datetime");
            entity.Property(e => e.BackupLabel).HasMaxLength(64);
            entity.Property(e => e.Bcc)
                .HasDefaultValue("")
                .HasColumnName("BCC");
            entity.Property(e => e.CaseId)
                .HasDefaultValue(0)
                .HasColumnName("CaseID");
            entity.Property(e => e.Cc)
                .HasDefaultValue("")
                .HasColumnName("CC");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dnis)
                .HasMaxLength(64)
                .HasColumnName("DNIS");
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
            entity.Property(e => e.IvrsId).HasColumnName("IvrsID");
            entity.Property(e => e.Pages).HasDefaultValue(0);
            entity.Property(e => e.PrevCallId)
                .HasDefaultValue(0)
                .HasColumnName("PrevCallID");
            entity.Property(e => e.PriorityId)
                .HasDefaultValue(0)
                .HasColumnName("PriorityID");
            entity.Property(e => e.ReadDateTime).HasColumnType("datetime");
            entity.Property(e => e.ReadFlag).HasDefaultValue((byte)0);
            entity.Property(e => e.RestoreKey).HasMaxLength(255);
            entity.Property(e => e.ResultId).HasColumnName("ResultID");
            entity.Property(e => e.Sender).HasMaxLength(64);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Subject)
                .HasMaxLength(1024)
                .HasDefaultValue("");
            entity.Property(e => e.ZipFileFolder).HasMaxLength(255);
            entity.Property(e => e.ZipPassword).HasMaxLength(255);
        });

        modelBuilder.Entity<MediaCallActionLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MediaCall_Assign_Log");

            entity.ToTable("MediaCall_Action_Log");

            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Project)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.UpdatedTime)
                .HasColumnType("datetime")
                .HasColumnName("Updated_Time");
        });

        modelBuilder.Entity<MediaCallCaseId>(entity =>
        {
            entity.HasKey(e => e.CaseId);

            entity.ToTable("MediaCall_CaseID");

            entity.Property(e => e.Remark)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<MediaCallStatus>(entity =>
        {
            entity.HasKey(e => e.CallId);

            entity.ToTable("MediaCall_Status");

            entity.Property(e => e.CallId)
                .ValueGeneratedNever()
                .HasColumnName("CallID");
            entity.Property(e => e.HandledCaseNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HandledDateTime).HasColumnType("datetime");
            entity.Property(e => e.Project)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<MediaCallStatusLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("MediaCall_Status_Log");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.HandledCaseNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HandledDateTime).HasColumnType("datetime");
            entity.Property(e => e.Project)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<MonitorAgent>(entity =>
        {
            entity.HasKey(e => e.Itemid);

            entity.ToTable("MonitorAgent");

            entity.HasIndex(e => new { e.Wiseid, e.Supervisorid }, "IX_MonitorAgent");

            entity.HasIndex(e => e.Agentid, "IX_MonitorAgent_1");

            entity.Property(e => e.TransactDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TransactUser)
                .HasMaxLength(50)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<MonitorAgentConfig>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_Agent_Config");

            entity.ToTable("MonitorAgentConfig");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.AgentId).HasColumnName("agentId");
            entity.Property(e => e.Iconviewitem)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("iconviewitem");
            entity.Property(e => e.Layoutid).HasColumnName("layoutid");
            entity.Property(e => e.Style)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("style");
        });

        modelBuilder.Entity<MonitorAgentRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MonitorAgentRole");

            entity.Property(e => e.AgentId).HasColumnName("agentId");
            entity.Property(e => e.ListAgentId)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("list_agentId");
            entity.Property(e => e.RootAgentId).HasColumnName("root_agentId");
            entity.Property(e => e.Uid)
                .ValueGeneratedOnAdd()
                .HasColumnName("uid");
        });

        modelBuilder.Entity<MonitorAgentSocialMedium>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TargetAgentId).HasColumnName("TargetAgentID");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp");
        });

        modelBuilder.Entity<MonitorConfigDatum>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_Config_UI");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.AgentId).HasColumnName("agentId");
            entity.Property(e => e.CfgData)
                .HasColumnType("image")
                .HasColumnName("cfgData");
            entity.Property(e => e.CfgName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cfgName");
            entity.Property(e => e.Typeid).HasColumnName("typeid");
        });

        modelBuilder.Entity<MonitorConfigIcon>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_Config_Icon");

            entity.ToTable("MonitorConfigIcon");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.AgentId).HasColumnName("agentId");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cname");
            entity.Property(e => e.Color)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("color");
            entity.Property(e => e.Dispname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dispname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Sn).HasColumnName("sn");
            entity.Property(e => e.Timelimit)
                .HasColumnType("smalldatetime")
                .HasColumnName("timelimit");
        });

        modelBuilder.Entity<MonitorConfigLayout>(entity =>
        {
            entity.HasKey(e => e.LayoutId);

            entity.ToTable("MonitorConfigLayout");

            entity.Property(e => e.LayoutData).HasColumnType("image");
            entity.Property(e => e.LayoutName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MonitorConfigLine>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_Config_Line");

            entity.ToTable("MonitorConfigLine");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.AgentId).HasColumnName("agentId");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Dispname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dispname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Sn).HasColumnName("sn");
        });

        modelBuilder.Entity<MonitorConfigRest>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_Config_Rest");

            entity.ToTable("MonitorConfigRest");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.AgentId).HasColumnName("agentId");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Dispname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dispname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Sn).HasColumnName("sn");
        });

        modelBuilder.Entity<MonitorConfigScheme>(entity =>
        {
            entity.HasKey(e => e.SchemeId);

            entity.ToTable("MonitorConfigScheme");

            entity.Property(e => e.SchemeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MonitorConfigSchemeNode>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MonitorConfigSchemeNode");

            entity.Property(e => e.Sn).HasColumnName("SN");
        });

        modelBuilder.Entity<MonitorConfigTabCtrl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MonitorConfigTabCtrl");

            entity.Property(e => e.CtrlId).HasColumnName("CtrlID");
            entity.Property(e => e.CtrlType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LayoutId).HasColumnName("LayoutID");
            entity.Property(e => e.Param).HasMaxLength(200);
            entity.Property(e => e.TabPageId).HasColumnName("TabPageID");
        });

        modelBuilder.Entity<MonitorConfigTabPage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MonitorConfigTabPage");

            entity.Property(e => e.ActiveCtrlId).HasColumnName("ActiveCtrlID");
            entity.Property(e => e.TabPageName).HasMaxLength(50);
        });

        modelBuilder.Entity<MonitorConsoleUser>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.ToTable("MonitorConsoleUser");

            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.TransactDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TransactUser)
                .HasMaxLength(50)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<MonitorDictionary>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MonitorDictionary");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameCn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NameCN");
            entity.Property(e => e.NameCt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NameCT");
        });

        modelBuilder.Entity<MonitorMsdbcfg>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("MonitorMSDBCfg");

            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Db)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DB");
            entity.Property(e => e.Description)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("description");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Server)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<MonitorService>(entity =>
        {
            entity.HasKey(e => e.Itemid);

            entity.ToTable("MonitorService");

            entity.HasIndex(e => new { e.Wiseid, e.Supervisorid }, "IX_MonitorService");

            entity.HasIndex(e => e.Serviceid, "IX_MonitorService_1");

            entity.Property(e => e.TransactDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TransactUser)
                .HasMaxLength(50)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<MonitorStatistic>(entity =>
        {
            entity.HasKey(e => new { e.TimeStamp, e.ServiceId, e.AcdgroupId });

            entity.ToTable("Monitor_Statistics");

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.AcdgroupId).HasColumnName("ACDGroupID");
            entity.Property(e => e.AbandonedCall).HasDefaultValue(0);
            entity.Property(e => e.AbandonedTime).HasDefaultValue(0);
            entity.Property(e => e.AcdgroupType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACDGroupType");
            entity.Property(e => e.AnsweredCall).HasDefaultValue(0);
            entity.Property(e => e.AnsweredTalkTime).HasDefaultValue(0);
            entity.Property(e => e.AvgAbandonedTime).HasDefaultValue(0);
            entity.Property(e => e.IncomingCall).HasDefaultValue(0);
            entity.Property(e => e.OutboundCall).HasDefaultValue(0);
            entity.Property(e => e.OutboundTalkTime).HasDefaultValue(0);
            entity.Property(e => e.PctAbandonedCall).HasDefaultValue(0);
        });

        modelBuilder.Entity<MonitorStatistics20200318>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Monitor_Statistics_20200318");

            entity.Property(e => e.AcdgroupId).HasColumnName("ACDGroupID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<MonitorStyleDataGrid>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("MonitorStyleDataGrid");

            entity.Property(e => e.Uid).HasColumnName("uid");
            entity.Property(e => e.Coloralter)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("coloralter");
            entity.Property(e => e.Colorgrid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colorgrid");
            entity.Property(e => e.Colorheader)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colorheader");
            entity.Property(e => e.Colorheaderbg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colorheaderbg");
            entity.Property(e => e.Colorrow)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("colorrow");
            entity.Property(e => e.Style)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("style");
        });

        modelBuilder.Entity<MonitorSupervisor>(entity =>
        {
            entity.HasKey(e => e.Itemid);

            entity.ToTable("MonitorSupervisor");

            entity.HasIndex(e => e.Wiseid, "IX_MonitorSupervisor");

            entity.HasIndex(e => e.Supervisorid, "IX_MonitorSupervisor_1");

            entity.Property(e => e.Rights).HasMaxLength(50);
            entity.Property(e => e.SendAni)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("SendANI");
            entity.Property(e => e.TransactDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TransactUser)
                .HasMaxLength(50)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<MonitorTabCtrlAgentList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MonitorTabCtrlAgentList");

            entity.Property(e => e.AgentId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AgentName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BreakTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DialTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FaxCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoldTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdleTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InCallCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InTalkTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InterCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InterTalkTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OtherTalkCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OtherTalkTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OutCallCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OutTalkCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OutTalkTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReadyTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SmsCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StationName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StatusTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TalkTime)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ViewAcd)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ViewACD");
            entity.Property(e => e.VmailCount)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VMailCount");
            entity.Property(e => e.WebCallCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.WebChatCount)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.WorkTime)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MonitorTerminal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("monitorTerminal");

            entity.Property(e => e.AgentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("agentName");
        });

        modelBuilder.Entity<MonitorTranLog>(entity =>
        {
            entity.ToTable("MonitorTranLog");

            entity.HasIndex(e => new { e.CallId, e.OdeviceId, e.DdeviceId, e.DdeviceType, e.OdeviceType }, "IX_MonitorTranLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.DdeviceId).HasColumnName("DDeviceID");
            entity.Property(e => e.DdeviceType).HasColumnName("DDeviceType");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.OdeviceId).HasColumnName("ODeviceID");
            entity.Property(e => e.OdeviceType).HasColumnName("ODeviceType");
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<MonitorWisePlatform>(entity =>
        {
            entity.HasKey(e => e.Wiseid);

            entity.ToTable("MonitorWisePlatform");

            entity.HasIndex(e => e.WiseName, "IX_MonitorWisePlatform").IsUnique();

            entity.HasIndex(e => e.WiseRmserver, "IX_MonitorWisePlatform_1").IsUnique();

            entity.Property(e => e.Odbc1)
                .HasMaxLength(255)
                .HasDefaultValue("")
                .HasColumnName("ODBC1");
            entity.Property(e => e.Odbc2)
                .HasMaxLength(255)
                .HasDefaultValue("")
                .HasColumnName("ODBC2");
            entity.Property(e => e.TransactDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TransactUser)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.WiseName).HasMaxLength(50);
            entity.Property(e => e.WiseRmserver)
                .HasMaxLength(50)
                .HasColumnName("WiseRMserver");
        });

        modelBuilder.Entity<OfficeHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Config");

            entity.ToTable("Office_hour");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.WeekDay).HasMaxLength(10);
        });

        modelBuilder.Entity<OutBlog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OutBlog");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.CommandType).HasDefaultValue(0);
            entity.Property(e => e.CommentOnId)
                .HasMaxLength(129)
                .HasColumnName("CommentOnID");
            entity.Property(e => e.Message).HasColumnType("ntext");
            entity.Property(e => e.Pic)
                .HasMaxLength(256)
                .HasColumnName("PIC");
            entity.Property(e => e.SenderName).HasMaxLength(129);
            entity.Property(e => e.SoundUrl).HasMaxLength(50);
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.WatchUrl).HasMaxLength(50);
        });

        modelBuilder.Entity<OutMail>(entity =>
        {
            entity.ToTable("OutMail");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Attachment)
                .HasColumnType("ntext")
                .HasColumnName("attachment");
            entity.Property(e => e.Bcc).HasColumnName("bcc");
            entity.Property(e => e.Cc).HasColumnName("cc");
            entity.Property(e => e.FromAddr)
                .HasMaxLength(65)
                .HasColumnName("fromAddr");
            entity.Property(e => e.Message)
                .HasColumnType("ntext")
                .HasColumnName("message");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Subject)
                .HasMaxLength(1000)
                .HasColumnName("subject");
            entity.Property(e => e.ToAddr).HasColumnName("toAddr");
        });

        modelBuilder.Entity<OutMediaJob>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OutMediaJob");

            entity.Property(e => e.Attachment).HasMaxLength(255);
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.CoverFile).HasMaxLength(255);
            entity.Property(e => e.FromAddr).HasMaxLength(50);
            entity.Property(e => e.FromName).HasMaxLength(50);
            entity.Property(e => e.G3tiffFile)
                .HasMaxLength(255)
                .HasColumnName("G3TiffFile");
            entity.Property(e => e.JobId)
                .HasMaxLength(50)
                .HasColumnName("JobID");
            entity.Property(e => e.Message).HasMaxLength(1024);
            entity.Property(e => e.Pbxid).HasColumnName("PBXID");
            entity.Property(e => e.QueueTime).HasColumnType("datetime");
            entity.Property(e => e.Subject).HasMaxLength(128);
            entity.Property(e => e.SubmitTime).HasColumnType("datetime");
            entity.Property(e => e.ToName).HasMaxLength(50);
            entity.Property(e => e.Toaddr).HasMaxLength(50);
        });

        modelBuilder.Entity<OutboundAni>(entity =>
        {
            entity.HasKey(e => new { e.ServiceName, e.OutboundType });

            entity.ToTable("OutboundANI");

            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OutboundType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ani)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ANI");
        });

        modelBuilder.Entity<OutboundFaxCall>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OutboundFaxCall");

            entity.Property(e => e.Ani)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ANI");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Dnis)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNIS");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Pbxconfig>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PBXConfig");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValueString)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PdexpIvrkeyFilter>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("PDExpIVRKeyFilter");

            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.KeyInResStr).HasMaxLength(20);
        });

        modelBuilder.Entity<PdexpResFilter>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("PDExpResFilter");

            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.RingbackOp)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("RingbackOP");
        });

        modelBuilder.Entity<PhoneBook>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PhoneBook");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.PhoneType).HasColumnName("phoneType");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .HasDefaultValue("")
                .HasColumnName("remarks");
        });

        modelBuilder.Entity<PhoneBookType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PhoneBookType");

            entity.Property(e => e.PhoneTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<PredictiveDialOutLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PredictiveDialOutLog");

            entity.HasIndex(e => new { e.CampaignId, e.TimeStamp }, "IX_PredictiveDialOutLog");

            entity.Property(e => e.AvgReadyTime).HasColumnName("Avg_ReadyTime");
            entity.Property(e => e.AvgTalkTime).HasColumnName("Avg_TalkTime");
            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
            entity.Property(e => e.DialOutRatio).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.DropCallRatio)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaxReadyTime).HasColumnName("Max_ReadyTime");
            entity.Property(e => e.MaxTalkTime).HasColumnName("Max_TalkTime");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<PredictiveList>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.CampaignId, e.Telephone });

            entity.ToTable("PredictiveList");

            entity.HasIndex(e => new { e.CampaignId, e.ContactTime, e.Attempt }, "IX_PredictiveList");

            entity.HasIndex(e => e.CurrCallId, "IX_PredictiveList_1");

            entity.HasIndex(e => e.CurrConnId, "IX_PredictiveList_2");

            entity.HasIndex(e => e.CustomerId, "IX_PredictiveList_3");

            entity.HasIndex(e => new { e.CampaignId, e.ScheduleTime, e.Attempt }, "IX_PredictiveList_4");

            entity.HasIndex(e => new { e.CampaignId, e.ContactResult }, "IX_PredictiveList_5");

            entity.HasIndex(e => new { e.CampaignId, e.MaxTalk }, "IX_PredictiveList_6");

            entity.HasIndex(e => new { e.CampaignId, e.CustStatus }, "IX_PredictiveList_7");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ani)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ANI");
            entity.Property(e => e.Attempt).HasDefaultValue(0);
            entity.Property(e => e.Audio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("audio");
            entity.Property(e => e.ContactResult).HasDefaultValue(0);
            entity.Property(e => e.ContactResult1).HasDefaultValue(0);
            entity.Property(e => e.ContactResult2).HasDefaultValue(0);
            entity.Property(e => e.ContactResult3).HasDefaultValue(0);
            entity.Property(e => e.ContactTime).HasColumnType("datetime");
            entity.Property(e => e.CurrCallId).HasColumnName("CurrCallID");
            entity.Property(e => e.CurrConnId).HasColumnName("CurrConnID");
            entity.Property(e => e.CustStatus)
                .HasDefaultValue(0)
                .HasColumnName("Cust_Status");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.FallbackAudio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fallback_audio");
            entity.Property(e => e.IbusinessFlag)
                .HasDefaultValue(0)
                .HasColumnName("IBusinessFlag");
            entity.Property(e => e.Ivrs).HasColumnName("IVRS");
            entity.Property(e => e.MaxTalk).HasDefaultValue(0);
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ScheduleTime).HasColumnType("datetime");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.TeleIndex).HasDefaultValue(0);
            entity.Property(e => e.Telephone1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telephone2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telephone3)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PredictiveLog>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.CampaignId, e.Attempt, e.CallId });

            entity.ToTable("PredictiveLog");

            entity.HasIndex(e => new { e.CampaignId, e.CustomerId, e.Attempt }, "IX_PredictiveLog");

            entity.HasIndex(e => e.CustomerId, "IX_PredictiveLog_1");

            entity.HasIndex(e => e.CallId, "IX_PredictiveLog_2");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
            entity.Property(e => e.CallId).HasColumnName("callID");
            entity.Property(e => e.ContactTime).HasColumnType("datetime");
            entity.Property(e => e.Telephone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReadyTime>(entity =>
        {
            entity.HasKey(e => new { e.CampaignId, e.StepId, e.ConditionId });

            entity.ToTable("ReadyTime");

            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
            entity.Property(e => e.StepId).HasColumnName("StepID");
            entity.Property(e => e.ConditionId).HasColumnName("ConditionID");
            entity.Property(e => e.Condition)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Formula)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ResTimeZoneCfg>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RES_TimeZoneCfg");

            entity.HasIndex(e => e.WdId, "IX_RES_TimeZoneCfg").IsUnique();

            entity.Property(e => e.BEnable).HasColumnName("bEnable");
            entity.Property(e => e.WdDesc)
                .HasMaxLength(10)
                .HasColumnName("wdDesc");
            entity.Property(e => e.WdId).HasColumnName("wdID");
        });

        modelBuilder.Entity<ReturnList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("returnList");

            entity.Property(e => e.Param).HasMaxLength(500);
        });

        modelBuilder.Entity<RptAcdex>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptACDEX");

            entity.HasIndex(e => new { e.GroupId, e.TypeId, e.TimeStamp }, "IX_rptACDEX");

            entity.Property(e => e.ActiveTime)
                .HasDefaultValue(0)
                .HasColumnName("active_time");
            entity.Property(e => e.Agentcount)
                .HasDefaultValue(0)
                .HasColumnName("agentcount");
            entity.Property(e => e.AnsweredDelay)
                .HasDefaultValue(0)
                .HasColumnName("answered_delay");
            entity.Property(e => e.BusyTime)
                .HasDefaultValue(0)
                .HasColumnName("busy_time");
            entity.Property(e => e.CallsAbandoned)
                .HasDefaultValue(0)
                .HasColumnName("calls_abandoned");
            entity.Property(e => e.CallsAbandonedAfterThreshold)
                .HasDefaultValue(0)
                .HasColumnName("calls_abandoned_after_threshold");
            entity.Property(e => e.CallsAnswered)
                .HasDefaultValue(0)
                .HasColumnName("calls_answered");
            entity.Property(e => e.CallsAnsweredAfterThreshold)
                .HasDefaultValue(0)
                .HasColumnName("calls_answered_after_threshold");
            entity.Property(e => e.CallsOffered)
                .HasDefaultValue(0)
                .HasColumnName("calls_offered");
            entity.Property(e => e.CallsOutbound)
                .HasDefaultValue(0)
                .HasColumnName("calls_outbound");
            entity.Property(e => e.GroupId).HasColumnName("groupID");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("groupName");
            entity.Property(e => e.InboundTalk)
                .HasDefaultValue(0)
                .HasColumnName("inbound_talk");
            entity.Property(e => e.Logintime)
                .HasDefaultValue(0L)
                .HasColumnName("logintime");
            entity.Property(e => e.OutboundTalk)
                .HasDefaultValue(0)
                .HasColumnName("outbound_talk");
            entity.Property(e => e.ServiceLevel)
                .HasDefaultValue(0)
                .HasColumnName("service_level");
            entity.Property(e => e.SumTalkTime).HasDefaultValue(0L);
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.TypeId)
                .HasDefaultValue(1)
                .HasColumnName("TypeID");
            entity.Property(e => e.WaitingTime)
                .HasDefaultValue(0)
                .HasColumnName("waiting_time");
        });

        modelBuilder.Entity<RptAcdgroup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptACDGroup");

            entity.HasIndex(e => new { e.TypeId, e.TimeStamp }, "IX_rptACDGroup");

            entity.HasIndex(e => new { e.AcdGroupId, e.CallInbound, e.TimeStamp }, "IX_rptACDGroup_1");

            entity.HasIndex(e => e.AcdGroupId, "IX_rptPoolDaily");

            entity.HasIndex(e => e.TimeStamp, "IX_rptPoolDaily_1");

            entity.HasIndex(e => new { e.AcdGroupId, e.TypeId, e.TimeStamp }, "IX_rptPoolDaily_2");

            entity.Property(e => e.AcdGroupId).HasColumnName("AcdGroupID");
            entity.Property(e => e.MediaEmailInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_email_in_H");
            entity.Property(e => e.MediaEmailInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_email_in_U");
            entity.Property(e => e.MediaEmailOutH)
                .HasDefaultValue(0)
                .HasColumnName("Media_email_out_H");
            entity.Property(e => e.MediaEmailOutU)
                .HasDefaultValue(0)
                .HasColumnName("Media_email_out_U");
            entity.Property(e => e.MediaFaxInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_fax_in_H");
            entity.Property(e => e.MediaFaxInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_fax_in_U");
            entity.Property(e => e.MediaFaxOutH)
                .HasDefaultValue(0)
                .HasColumnName("Media_fax_out_H");
            entity.Property(e => e.MediaFaxOutU)
                .HasDefaultValue(0)
                .HasColumnName("Media_fax_out_U");
            entity.Property(e => e.MediaVmailInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_vmail_in_H");
            entity.Property(e => e.MediaVmailInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_vmail_in_U");
            entity.Property(e => e.MediaWebcallInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_webcall_in_H");
            entity.Property(e => e.MediaWebcallInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_webcall_in_U");
            entity.Property(e => e.MediaWebchatInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_webchat_in_H");
            entity.Property(e => e.MediaWebchatInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_webchat_in_U");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<RptAcdtime>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_ACDTime");

            entity.HasIndex(e => new { e.Acdid, e.TimeStamp }, "IX_Rpt_ACDTime");

            entity.HasIndex(e => new { e.TimeStamp, e.Acdid }, "NonClusteredIndex-20190830-094632");

            entity.Property(e => e.Acdid).HasColumnName("ACDID");
            entity.Property(e => e.BreakCount).HasDefaultValue(0);
            entity.Property(e => e.BreakTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.BreakTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.IdleCount).HasDefaultValue(0);
            entity.Property(e => e.IdleTime)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)");
            entity.Property(e => e.IdleTimeMax)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InAbandonTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InAbandonTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InCallAnsCountBfwd).HasColumnName("InCallAnsCountBFwd");
            entity.Property(e => e.InCallAnsSla01count).HasColumnName("InCallAnsSLA01Count");
            entity.Property(e => e.InCallAnsSla02count).HasColumnName("InCallAnsSLA02Count");
            entity.Property(e => e.InCallAnsSla03count).HasColumnName("InCallAnsSLA03Count");
            entity.Property(e => e.InCallOfferCountBfwd).HasColumnName("InCallOfferCountBFwd");
            entity.Property(e => e.InRecvTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InRecvTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InWaitingTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InWaitingTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterCallCountBfwd).HasColumnName("InterCallCountBFwd");
            entity.Property(e => e.InterTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.LoginAgentTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.MediaInBlogH).HasColumnName("Media_In_Blog_H");
            entity.Property(e => e.MediaInBlogU).HasColumnName("Media_In_Blog_U");
            entity.Property(e => e.MediaInEmailH).HasColumnName("Media_In_Email_H");
            entity.Property(e => e.MediaInEmailU).HasColumnName("Media_In_Email_U");
            entity.Property(e => e.MediaInFaxH).HasColumnName("Media_In_Fax_H");
            entity.Property(e => e.MediaInFaxU).HasColumnName("Media_In_Fax_U");
            entity.Property(e => e.MediaInSmsH).HasColumnName("Media_In_SMS_H");
            entity.Property(e => e.MediaInSmsU).HasColumnName("Media_In_SMS_U");
            entity.Property(e => e.MediaInVmailH).HasColumnName("Media_In_Vmail_H");
            entity.Property(e => e.MediaInVmailU).HasColumnName("Media_In_Vmail_U");
            entity.Property(e => e.MediaInWebCallH).HasColumnName("Media_In_WebCall_H");
            entity.Property(e => e.MediaInWebCallU).HasColumnName("Media_In_WebCall_U");
            entity.Property(e => e.MediaInWebChatH).HasColumnName("Media_In_WebChat_H");
            entity.Property(e => e.MediaInWebChatU).HasColumnName("Media_In_WebChat_U");
            entity.Property(e => e.MediaOutBlog).HasColumnName("Media_Out_Blog");
            entity.Property(e => e.MediaOutEmail).HasColumnName("Media_Out_Email");
            entity.Property(e => e.MediaOutFax).HasColumnName("Media_Out_Fax");
            entity.Property(e => e.MediaOutSms).HasColumnName("Media_Out_SMS");
            entity.Property(e => e.OfAbanByDevice).HasColumnName("OF_AbanByDevice");
            entity.Property(e => e.OfInAbandonTime)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InAbandonTime");
            entity.Property(e => e.OfInAbandonTimeMax)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InAbandonTimeMax");
            entity.Property(e => e.OfInCallOfferCount).HasColumnName("OF_InCallOfferCount");
            entity.Property(e => e.OfInRecvTime)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InRecvTime");
            entity.Property(e => e.OfInRecvTimeMax)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InRecvTimeMax");
            entity.Property(e => e.OfInWaitingTime)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InWaitingTime");
            entity.Property(e => e.OfInWaitingTimeMax)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InWaitingTimeMax");
            entity.Property(e => e.OfRdBlogIn)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_BlogIn");
            entity.Property(e => e.OfRdEmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Email");
            entity.Property(e => e.OfRdFax)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Fax");
            entity.Property(e => e.OfRdSms)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_SMS");
            entity.Property(e => e.OfRdVmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_VMail");
            entity.Property(e => e.OfRdWebCall)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebCall");
            entity.Property(e => e.OfRdWebChat)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebChat");
            entity.Property(e => e.OfRdcallCount)
                .HasDefaultValue(0)
                .HasColumnName("OF_RDCallCount");
            entity.Property(e => e.OtherCallCountBfwd).HasColumnName("OtherCallCountBFwd");
            entity.Property(e => e.OtherTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutCallCountBfwd).HasColumnName("OutCallCountBFwd");
            entity.Property(e => e.OutDialingTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTranVmail).HasColumnName("OutTranVMail");
            entity.Property(e => e.PdcallCount).HasColumnName("PDCallCount");
            entity.Property(e => e.PdcallCountBfwd).HasColumnName("PDCallCountBFwd");
            entity.Property(e => e.ReadyCount).HasDefaultValue(0);
            entity.Property(e => e.ReadyTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.ReadyTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.RecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RecordID");
            entity.Property(e => e.Sla01).HasColumnName("SLA01");
            entity.Property(e => e.Sla02).HasColumnName("SLA02");
            entity.Property(e => e.Sla03).HasColumnName("SLA03");
            entity.Property(e => e.TalkCount).HasDefaultValue(0);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TotWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.TotWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.WorkCount).HasDefaultValue(0);
            entity.Property(e => e.WorkTime)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)");
            entity.Property(e => e.WorkTimeMax)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)");
            entity.Property(e => e.WriteDbtime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("WriteDBTime");
        });

        modelBuilder.Entity<RptAcdtimeNew>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rpt_ACDTime_new");

            entity.HasIndex(e => new { e.TimeStamp, e.AcdgroupId }, "NonClusteredIndex-20210330-150643").HasFillFactor(80);

            entity.Property(e => e.AcdgroupId).HasColumnName("ACDGroupID");
            entity.Property(e => e.Sla10count).HasColumnName("SLA10Count");
            entity.Property(e => e.Sla120count).HasColumnName("SLA120Count");
            entity.Property(e => e.Sla15count).HasColumnName("SLA15Count");
            entity.Property(e => e.Sla20count).HasColumnName("SLA20Count");
            entity.Property(e => e.Sla30count).HasColumnName("SLA30Count");
            entity.Property(e => e.Sla40count).HasColumnName("SLA40Count");
            entity.Property(e => e.Sla50count).HasColumnName("SLA50Count");
            entity.Property(e => e.Sla5count).HasColumnName("SLA5Count");
            entity.Property(e => e.Sla60count).HasColumnName("SLA60Count");
            entity.Property(e => e.Sla90count).HasColumnName("SLA90Count");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.TotalAcdCallCount)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("total_acd_call_count");
            entity.Property(e => e.WriteDbtime)
                .HasColumnType("datetime")
                .HasColumnName("WriteDBTime");
        });

        modelBuilder.Entity<RptAcdtrace>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_ACDTrace");

            entity.HasIndex(e => new { e.Uid, e.Timestamp }, "IX_Rpt_ACDTrace");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<RptAgent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptAgent");

            entity.HasIndex(e => e.AgentId, "IX_rptAgent");

            entity.HasIndex(e => new { e.AgentId, e.TypeId, e.TimeStamp }, "IX_rptAgent_1");

            entity.HasIndex(e => e.TimeStamp, "IX_rptAgent_2");

            entity.HasIndex(e => new { e.TypeId, e.TimeStamp }, "IX_rptAgent_3");

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.CallAnsAcd)
                .HasDefaultValue(0)
                .HasColumnName("CallAnsACD");
            entity.Property(e => e.CallAnsFlow).HasDefaultValue(0);
            entity.Property(e => e.CallAnsIntercom).HasDefaultValue(0);
            entity.Property(e => e.MediaEmailInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_email_in_H");
            entity.Property(e => e.MediaEmailInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_email_in_U");
            entity.Property(e => e.MediaEmailOutH)
                .HasDefaultValue(0)
                .HasColumnName("Media_email_out_H");
            entity.Property(e => e.MediaEmailOutU)
                .HasDefaultValue(0)
                .HasColumnName("Media_email_out_U");
            entity.Property(e => e.MediaFaxInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_fax_in_H");
            entity.Property(e => e.MediaFaxInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_fax_in_U");
            entity.Property(e => e.MediaFaxOutH)
                .HasDefaultValue(0)
                .HasColumnName("Media_fax_out_H");
            entity.Property(e => e.MediaFaxOutU)
                .HasDefaultValue(0)
                .HasColumnName("Media_fax_out_U");
            entity.Property(e => e.MediaVmailInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_vmail_in_H");
            entity.Property(e => e.MediaVmailInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_vmail_in_U");
            entity.Property(e => e.MediaWebcallInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_webcall_in_H");
            entity.Property(e => e.MediaWebcallInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_webcall_in_U");
            entity.Property(e => e.MediaWebchatInH)
                .HasDefaultValue(0)
                .HasColumnName("Media_webchat_in_H");
            entity.Property(e => e.MediaWebchatInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_webchat_in_U");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<RptAgentEx>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptAgentEX");

            entity.HasIndex(e => new { e.AgentId, e.TimeStamp, e.TypeId }, "IX_rptAgentEX");

            entity.Property(e => e.AgentId).HasColumnName("agentID");
            entity.Property(e => e.AgentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("agentName");
            entity.Property(e => e.AnsweredShort).HasColumnName("answeredShort");
            entity.Property(e => e.Busy).HasColumnName("busy");
            entity.Property(e => e.CallsAnswered)
                .HasDefaultValue(0)
                .HasColumnName("calls_answered");
            entity.Property(e => e.CallsOutbound).HasColumnName("calls_outbound");
            entity.Property(e => e.DirectLine).HasColumnName("directLine");
            entity.Property(e => e.Internal).HasColumnName("internal");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Logintime)
                .HasDefaultValue(0L)
                .HasColumnName("logintime");
            entity.Property(e => e.NotReady).HasColumnName("notReady");
            entity.Property(e => e.SumTalkTime).HasDefaultValue(0L);
            entity.Property(e => e.TalkIntercom).HasColumnName("talkIntercom");
            entity.Property(e => e.TalkOutbound).HasColumnName("talkOutbound");
            entity.Property(e => e.TalkTimeAvg).HasColumnName("talkTimeAvg");
            entity.Property(e => e.TalkTimeDirectLine).HasColumnName("talkTimeDirectLine");
            entity.Property(e => e.TalkTimeTotal).HasColumnName("talkTimeTotal");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Transfer).HasColumnName("transfer");
            entity.Property(e => e.TypeId)
                .HasDefaultValue(1)
                .HasColumnName("TypeID");
        });

        modelBuilder.Entity<RptAgentLogin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptAgentLogin");

            entity.HasIndex(e => e.AgentId, "IX_rptStaffLogin");

            entity.HasIndex(e => new { e.AgentId, e.TimeStamp }, "IX_rptStaffLogin_1");

            entity.HasIndex(e => e.TimeStamp, "IX_rptStaffLogin_2");

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.Duration)
                .HasMaxLength(50)
                .HasDefaultValue("00:00:00");
            entity.Property(e => e.LoginTime)
                .HasMaxLength(500)
                .HasDefaultValue("");
            entity.Property(e => e.LogoutTime)
                .HasMaxLength(500)
                .HasDefaultValue("");
            entity.Property(e => e.Station)
                .HasMaxLength(500)
                .HasDefaultValue("");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<RptAgentTimeNew>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_AgentTime_new");

            entity.HasIndex(e => new { e.TimeStamp, e.AgentId }, "NonClusteredIndex-20210330-150705").HasFillFactor(80);

            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.AnsweredCall).HasColumnName("answered_call");
            entity.Property(e => e.HoldCallTime).HasColumnName("hold_call_time");
            entity.Property(e => e.IdleTime).HasColumnName("idle_time");
            entity.Property(e => e.InTalkTime).HasColumnName("in_talk_time");
            entity.Property(e => e.InWorkingTime).HasColumnName("in_working_time");
            entity.Property(e => e.LoginTime).HasColumnName("login_time");
            entity.Property(e => e.MiscDutyTime).HasColumnName("misc_duty_time");
            entity.Property(e => e.MiscEscalateTime).HasColumnName("misc_escalate_time");
            entity.Property(e => e.MiscOtherTime).HasColumnName("misc_other_time");
            entity.Property(e => e.MiscRestTime).HasColumnName("misc_rest_time");
            entity.Property(e => e.OtherTime).HasColumnName("other_time");
            entity.Property(e => e.OutTalkTime).HasColumnName("out_talk_time");
            entity.Property(e => e.OutWorkingTime).HasColumnName("out_working_time");
            entity.Property(e => e.OutboundAttemptCall).HasColumnName("outbound_attempt_call");
            entity.Property(e => e.OutboundSuccessCall).HasColumnName("outbound_success_call");
            entity.Property(e => e.ReadyTime).HasColumnName("ready_time");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.VoiceMail).HasColumnName("voice_mail");
            entity.Property(e => e.WriteDbtime)
                .HasColumnType("datetime")
                .HasColumnName("WriteDBTime");
        });

        modelBuilder.Entity<RptIvrshourly>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptIVRSHourly");

            entity.Property(e => e.CreateDate).HasMaxLength(30);
            entity.Property(e => e.Desc)
                .HasMaxLength(200)
                .HasColumnName("desc");
            entity.Property(e => e.Keypress)
                .HasMaxLength(50)
                .HasColumnName("keypress");
            entity.Property(e => e.OrderSequence).HasColumnName("orderSequence");
            entity.Property(e => e.ServiceId)
                .HasMaxLength(100)
                .HasColumnName("serviceID");
            entity.Property(e => e._0000).HasColumnName("00:00");
            entity.Property(e => e._0100).HasColumnName("01:00");
            entity.Property(e => e._0200).HasColumnName("02:00");
            entity.Property(e => e._0300).HasColumnName("03:00");
            entity.Property(e => e._0400).HasColumnName("04:00");
            entity.Property(e => e._0500).HasColumnName("05:00");
            entity.Property(e => e._0600).HasColumnName("06:00");
            entity.Property(e => e._0700).HasColumnName("07:00");
            entity.Property(e => e._0800).HasColumnName("08:00");
            entity.Property(e => e._0900).HasColumnName("09:00");
            entity.Property(e => e._1000).HasColumnName("10:00");
            entity.Property(e => e._1100).HasColumnName("11:00");
            entity.Property(e => e._1200).HasColumnName("12:00");
            entity.Property(e => e._1300).HasColumnName("13:00");
            entity.Property(e => e._1400).HasColumnName("14:00");
            entity.Property(e => e._1500).HasColumnName("15:00");
            entity.Property(e => e._1600).HasColumnName("16:00");
            entity.Property(e => e._1700).HasColumnName("17:00");
            entity.Property(e => e._1800).HasColumnName("18:00");
            entity.Property(e => e._1900).HasColumnName("19:00");
            entity.Property(e => e._2000).HasColumnName("20:00");
            entity.Property(e => e._2100).HasColumnName("21:00");
            entity.Property(e => e._2200).HasColumnName("22:00");
            entity.Property(e => e._2300).HasColumnName("23:00");
        });

        modelBuilder.Entity<RptMediaService>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptMediaService");

            entity.HasIndex(e => new { e.ServiceId, e.TypeId }, "IX_rptMediaService");

            entity.Property(e => e.MediaEmailInH).HasColumnName("Media_email_in_H");
            entity.Property(e => e.MediaEmailInU).HasColumnName("Media_email_in_U");
            entity.Property(e => e.MediaEmailOutH).HasColumnName("Media_email_out_H");
            entity.Property(e => e.MediaEmailOutU).HasColumnName("Media_email_out_U");
            entity.Property(e => e.MediaFaxInH).HasColumnName("Media_fax_in_H");
            entity.Property(e => e.MediaFaxInU).HasColumnName("Media_fax_in_U");
            entity.Property(e => e.MediaFaxOutH).HasColumnName("Media_fax_out_H");
            entity.Property(e => e.MediaFaxOutU).HasColumnName("Media_fax_out_U");
            entity.Property(e => e.MediaVmailInH).HasColumnName("Media_vmail_in_H");
            entity.Property(e => e.MediaVmailInU).HasColumnName("Media_vmail_in_U");
            entity.Property(e => e.MediaWebcallInH).HasColumnName("Media_webcall_in_H");
            entity.Property(e => e.MediaWebcallInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_webcall_in_U");
            entity.Property(e => e.MediaWebchatInH).HasColumnName("Media_webchat_in_H");
            entity.Property(e => e.MediaWebchatInU)
                .HasDefaultValue(0)
                .HasColumnName("Media_webchat_in_U");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<RptParkTime>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_ParkTime");

            entity.HasIndex(e => new { e.ParkId, e.TimeStamp }, "IX_Rpt_ParkTime");

            entity.Property(e => e.InAbandonTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InAbandonTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InCallAnsCountBfwd).HasColumnName("InCallAnsCountBFwd");
            entity.Property(e => e.InCallAnsSla01count).HasColumnName("InCallAnsSLA01Count");
            entity.Property(e => e.InCallAnsSla02count).HasColumnName("InCallAnsSLA02Count");
            entity.Property(e => e.InCallAnsSla03count).HasColumnName("InCallAnsSLA03Count");
            entity.Property(e => e.InCallOfferCountBfwd).HasColumnName("InCallOfferCountBFwd");
            entity.Property(e => e.InTransCount).HasDefaultValue(0);
            entity.Property(e => e.InWaitingTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InWaitingTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.MediaInBlogU).HasColumnName("Media_In_Blog_U");
            entity.Property(e => e.MediaInEmailU).HasColumnName("Media_In_Email_U");
            entity.Property(e => e.MediaInFaxU).HasColumnName("Media_In_Fax_U");
            entity.Property(e => e.MediaInSmsU).HasColumnName("Media_In_SMS_U");
            entity.Property(e => e.MediaInVmailU).HasColumnName("Media_In_Vmail_U");
            entity.Property(e => e.MediaInWebCallU).HasColumnName("Media_In_WebCall_U");
            entity.Property(e => e.MediaInWebChatU).HasColumnName("Media_In_WebChat_U");
            entity.Property(e => e.OfInAbandonTime)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InAbandonTime");
            entity.Property(e => e.OfInAbandonTimeMax)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InAbandonTimeMax");
            entity.Property(e => e.OfInCallOfferCount)
                .HasDefaultValue(0)
                .HasColumnName("OF_InCallOfferCount");
            entity.Property(e => e.OfInWaitingTime)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InWaitingTime");
            entity.Property(e => e.OfInWaitingTimeMax)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InWaitingTimeMax");
            entity.Property(e => e.OfRdBlogIn)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_BlogIn");
            entity.Property(e => e.OfRdEmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Email");
            entity.Property(e => e.OfRdFax)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Fax");
            entity.Property(e => e.OfRdSms)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_SMS");
            entity.Property(e => e.OfRdVmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_VMail");
            entity.Property(e => e.OfRdWebCall)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebCall");
            entity.Property(e => e.OfRdWebChat)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebChat");
            entity.Property(e => e.OfRdcallCount)
                .HasDefaultValue(0)
                .HasColumnName("OF_RDCallCount");
            entity.Property(e => e.OutTranVmail).HasColumnName("OutTranVMail");
            entity.Property(e => e.ParkId).HasColumnName("ParkID");
            entity.Property(e => e.RecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RecordID");
            entity.Property(e => e.Sla01).HasColumnName("SLA01");
            entity.Property(e => e.Sla02).HasColumnName("SLA02");
            entity.Property(e => e.Sla03).HasColumnName("SLA03");
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.WriteDbtime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("WriteDBTime");
        });

        modelBuilder.Entity<RptParkTrace>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_ParkTrace");

            entity.HasIndex(e => new { e.Uid, e.Timestamp }, "IX_Rpt_ParkTrace");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<RptPool>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptPool");

            entity.HasIndex(e => e.PoolId, "IX_rptPoolDaily");

            entity.HasIndex(e => e.TimeStamp, "IX_rptPoolDaily_1");

            entity.HasIndex(e => new { e.PoolId, e.TypeId, e.TimeStamp }, "IX_rptPoolDaily_2");

            entity.Property(e => e.PoolId).HasColumnName("PoolID");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<RptServEx>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptServEX");

            entity.HasIndex(e => new { e.ServId, e.TypeId, e.TimeStamp }, "IX_rptServEX");

            entity.Property(e => e.ActiveTime)
                .HasDefaultValue(0)
                .HasColumnName("active_time");
            entity.Property(e => e.Agentcount)
                .HasDefaultValue(0)
                .HasColumnName("agentcount");
            entity.Property(e => e.AnsweredDelay)
                .HasDefaultValue(0)
                .HasColumnName("answered_delay");
            entity.Property(e => e.BusyTime)
                .HasDefaultValue(0)
                .HasColumnName("busy_time");
            entity.Property(e => e.CallsAbandoned)
                .HasDefaultValue(0)
                .HasColumnName("calls_abandoned");
            entity.Property(e => e.CallsAbandonedAfterThreshold)
                .HasDefaultValue(0)
                .HasColumnName("calls_abandoned_after_threshold");
            entity.Property(e => e.CallsAnswered)
                .HasDefaultValue(0)
                .HasColumnName("calls_answered");
            entity.Property(e => e.CallsAnsweredAfterThreshold)
                .HasDefaultValue(0)
                .HasColumnName("calls_answered_after_threshold");
            entity.Property(e => e.CallsOffered)
                .HasDefaultValue(0)
                .HasColumnName("calls_offered");
            entity.Property(e => e.CallsOutbound)
                .HasDefaultValue(0)
                .HasColumnName("calls_outbound");
            entity.Property(e => e.InboundTalk)
                .HasDefaultValue(0)
                .HasColumnName("inbound_talk");
            entity.Property(e => e.Logintime)
                .HasDefaultValue(0L)
                .HasColumnName("logintime");
            entity.Property(e => e.OutboundTalk)
                .HasDefaultValue(0)
                .HasColumnName("outbound_talk");
            entity.Property(e => e.ServId).HasColumnName("ServID");
            entity.Property(e => e.ServName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceLevel)
                .HasDefaultValue(0)
                .HasColumnName("service_level");
            entity.Property(e => e.SumTalkTime).HasDefaultValue(0L);
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.TypeId)
                .HasDefaultValue(1)
                .HasColumnName("TypeID");
            entity.Property(e => e.WaitingTime)
                .HasDefaultValue(0)
                .HasColumnName("waiting_time");
        });

        modelBuilder.Entity<RptServTime>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_ServTime");

            entity.HasIndex(e => new { e.Service, e.TimeStamp }, "IX_Rpt_ServTime");

            entity.HasIndex(e => new { e.TimeStamp, e.Service }, "NonClusteredIndex-20190830-094727");

            entity.Property(e => e.InAbandonTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InAbandonTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InCallAnsSla01count).HasColumnName("InCallAnsSLA01Count");
            entity.Property(e => e.InCallAnsSla02count).HasColumnName("InCallAnsSLA02Count");
            entity.Property(e => e.InCallAnsSla03count).HasColumnName("InCallAnsSLA03Count");
            entity.Property(e => e.InCallCountBfwd).HasColumnName("InCallCountBFwd");
            entity.Property(e => e.InRecvTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InRecvTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InWaitingTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InWaitingTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.Ivrstime)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("IVRSTime");
            entity.Property(e => e.IvrstimeMax)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("IVRSTimeMax");
            entity.Property(e => e.MediaInBlogH).HasColumnName("Media_In_Blog_H");
            entity.Property(e => e.MediaInBlogU).HasColumnName("Media_In_Blog_U");
            entity.Property(e => e.MediaInEmailH).HasColumnName("Media_In_Email_H");
            entity.Property(e => e.MediaInEmailU).HasColumnName("Media_In_Email_U");
            entity.Property(e => e.MediaInFaxH).HasColumnName("Media_In_Fax_H");
            entity.Property(e => e.MediaInFaxU).HasColumnName("Media_In_Fax_U");
            entity.Property(e => e.MediaInSmsH).HasColumnName("Media_In_SMS_H");
            entity.Property(e => e.MediaInSmsU).HasColumnName("Media_In_SMS_U");
            entity.Property(e => e.MediaInVmailH).HasColumnName("Media_In_Vmail_H");
            entity.Property(e => e.MediaInVmailU).HasColumnName("Media_In_Vmail_U");
            entity.Property(e => e.MediaInWebCallH).HasColumnName("Media_In_WebCall_H");
            entity.Property(e => e.MediaInWebCallU).HasColumnName("Media_In_WebCall_U");
            entity.Property(e => e.MediaInWebChatH).HasColumnName("Media_In_WebChat_H");
            entity.Property(e => e.MediaInWebChatU).HasColumnName("Media_In_WebChat_U");
            entity.Property(e => e.MediaOutBlog).HasColumnName("Media_Out_Blog");
            entity.Property(e => e.MediaOutEmail).HasColumnName("Media_Out_Email");
            entity.Property(e => e.MediaOutFax).HasColumnName("Media_Out_Fax");
            entity.Property(e => e.MediaOutSms).HasColumnName("Media_Out_SMS");
            entity.Property(e => e.OfAbanByDevice).HasColumnName("OF_AbanByDevice");
            entity.Property(e => e.OfInAbandonTime)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InAbandonTime");
            entity.Property(e => e.OfInAbandonTimeMax)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InAbandonTimeMax");
            entity.Property(e => e.OfInRecvTime)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InRecvTime");
            entity.Property(e => e.OfInRecvTimeMax)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InRecvTimeMax");
            entity.Property(e => e.OfInWaitingTime)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InWaitingTime");
            entity.Property(e => e.OfInWaitingTimeMax)
                .HasColumnType("decimal(13, 3)")
                .HasColumnName("OF_InWaitingTimeMax");
            entity.Property(e => e.OfRdBlogIn)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_BlogIn");
            entity.Property(e => e.OfRdEmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Email");
            entity.Property(e => e.OfRdFax)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Fax");
            entity.Property(e => e.OfRdSms)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_SMS");
            entity.Property(e => e.OfRdVmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_VMail");
            entity.Property(e => e.OfRdWebCall)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebCall");
            entity.Property(e => e.OfRdWebChat)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebChat");
            entity.Property(e => e.OfRdcallCount)
                .HasDefaultValue(0)
                .HasColumnName("OF_RDCallCount");
            entity.Property(e => e.OutCallCountBfwd).HasColumnName("OutCallCountBFwd");
            entity.Property(e => e.OutDialingTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTranVmail).HasColumnName("OutTranVMail");
            entity.Property(e => e.RecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RecordID");
            entity.Property(e => e.Sla01).HasColumnName("SLA01");
            entity.Property(e => e.Sla02).HasColumnName("SLA02");
            entity.Property(e => e.Sla03).HasColumnName("SLA03");
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.WriteDbtime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("WriteDBTime");
        });

        modelBuilder.Entity<RptServTrace>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_ServTrace");

            entity.HasIndex(e => new { e.Uid, e.Timestamp }, "IX_Rpt_ServTrace");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<RptServiceIn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptServiceIn");

            entity.HasIndex(e => e.ServiceId, "IX_rptServiceIn");

            entity.HasIndex(e => new { e.ServiceId, e.TypeId, e.TimeStamp }, "IX_rptServiceIn_1");

            entity.HasIndex(e => e.TimeStamp, "IX_rptServiceIn_2");

            entity.HasIndex(e => new { e.TypeId, e.TimeStamp }, "IX_rptServiceIn_3");

            entity.Property(e => e.CallAcdqueue).HasColumnName("CallACDQueue");
            entity.Property(e => e.Cyc).HasDefaultValue(5);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
            entity.Property(e => e.VmailCnt).HasColumnName("VMailCnt");
        });

        modelBuilder.Entity<RptServiceOut>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rptServiceOut");

            entity.HasIndex(e => e.ServiceId, "IX_rptServiceOut");

            entity.HasIndex(e => new { e.ServiceId, e.TypeId, e.TimeStamp }, "IX_rptServiceOut_1");

            entity.HasIndex(e => e.TimeStamp, "IX_rptServiceOut_2");

            entity.HasIndex(e => new { e.TypeId, e.TimeStamp }, "IX_rptServiceOut_3");

            entity.Property(e => e.CallWrongTelNo).HasColumnName("CallWrongTelNO");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<RptServiceTimeNew>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rpt_ServiceTime_new");

            entity.HasIndex(e => new { e.TimeStamp, e.ServiceId }, "NonClusteredIndex-20210330-150720").HasFillFactor(80);

            entity.Property(e => e.AbandonedCall).HasColumnName("abandoned_call");
            entity.Property(e => e.AbandonedTime).HasColumnName("abandoned_time");
            entity.Property(e => e.AnsweredCall).HasColumnName("answered_call");
            entity.Property(e => e.InEmail).HasColumnName("in_email");
            entity.Property(e => e.InTalkTime).HasColumnName("in_talk_time");
            entity.Property(e => e.InWorkingTime).HasColumnName("in_working_time");
            entity.Property(e => e.IvrsOnly).HasColumnName("ivrs_only");
            entity.Property(e => e.OutTalkTime).HasColumnName("out_talk_time");
            entity.Property(e => e.OutWorkingTime).HasColumnName("out_working_time");
            entity.Property(e => e.OutboundCount).HasColumnName("outbound_count");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.Sla40).HasColumnName("sla_40");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Voicemail).HasColumnName("voicemail");
            entity.Property(e => e.WaitingTime).HasColumnName("waiting_time");
            entity.Property(e => e.WriteDbtime)
                .HasColumnType("datetime")
                .HasColumnName("WriteDBTime");
        });

        modelBuilder.Entity<RptStaffLogin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_StaffLogin");

            entity.HasIndex(e => new { e.LoginId, e.LoginTime }, "IX_Rpt_StaffLogin");

            entity.Property(e => e.BreakTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.BreakTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.DialTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.HoldTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.HoldTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.IdleTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.IdleTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.LoginId).HasColumnName("LoginID");
            entity.Property(e => e.LoginTime).HasColumnType("datetime");
            entity.Property(e => e.LogoutTime).HasColumnType("datetime");
            entity.Property(e => e.MediaInBlogH).HasColumnName("Media_In_Blog_H");
            entity.Property(e => e.MediaInBlogU).HasColumnName("Media_In_Blog_U");
            entity.Property(e => e.MediaInEmailH).HasColumnName("Media_In_Email_H");
            entity.Property(e => e.MediaInEmailU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_Email_U");
            entity.Property(e => e.MediaInFaxH).HasColumnName("Media_In_Fax_H");
            entity.Property(e => e.MediaInFaxU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_Fax_U");
            entity.Property(e => e.MediaInSmsH).HasColumnName("Media_In_SMS_H");
            entity.Property(e => e.MediaInSmsU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_SMS_U");
            entity.Property(e => e.MediaInVmailH).HasColumnName("Media_In_Vmail_H");
            entity.Property(e => e.MediaInVmailU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_Vmail_U");
            entity.Property(e => e.MediaInWebCallH).HasColumnName("Media_In_WebCall_H");
            entity.Property(e => e.MediaInWebCallU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_WebCall_U");
            entity.Property(e => e.MediaInWebChatH).HasColumnName("Media_In_WebChat_H");
            entity.Property(e => e.MediaInWebChatU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_WebChat_U");
            entity.Property(e => e.MediaOutBlog).HasColumnName("Media_Out_Blog");
            entity.Property(e => e.MediaOutEmail).HasColumnName("Media_Out_Email");
            entity.Property(e => e.MediaOutFax).HasColumnName("Media_Out_Fax");
            entity.Property(e => e.MediaOutSms).HasColumnName("Media_Out_SMS");
            entity.Property(e => e.MediaWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.MediaWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OfInCallCount).HasColumnName("OF_InCallCount");
            entity.Property(e => e.OfRdBlogIn)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_BlogIn");
            entity.Property(e => e.OfRdEmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Email");
            entity.Property(e => e.OfRdFax)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Fax");
            entity.Property(e => e.OfRdSms)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_SMS");
            entity.Property(e => e.OfRdVmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_VMail");
            entity.Property(e => e.OfRdWebCall)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebCall");
            entity.Property(e => e.OfRdWebChat)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebChat");
            entity.Property(e => e.OnlineTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherTime)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherTimeMax)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutCallTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.PdcallCount).HasColumnName("PDCallCount");
            entity.Property(e => e.ReadyTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.ReadyTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.RecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RecordID");
        });

        modelBuilder.Entity<RptStaffLoginTrace>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_StaffLoginTrace");

            entity.HasIndex(e => new { e.Uid, e.Timestamp }, "IX_Rpt_StaffLoginTrace");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<RptStaffTime>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_StaffTime");

            entity.HasIndex(e => new { e.LoginId, e.TimeStamp }, "IX_Rpt_StaffTime");

            entity.HasIndex(e => new { e.TimeStamp, e.LoginId }, "NonClusteredIndex-20190830-094801");

            entity.Property(e => e.BreakTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.BreakTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.DialTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.HoldTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.HoldTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.IdleTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.IdleTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InCallCountBfwd).HasColumnName("InCallCountBFwd");
            entity.Property(e => e.InTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterCallCountBfwd).HasColumnName("InterCallCountBFwd");
            entity.Property(e => e.InterTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.LoginId).HasColumnName("LoginID");
            entity.Property(e => e.MediaInBlogH).HasColumnName("Media_In_Blog_H");
            entity.Property(e => e.MediaInBlogU).HasColumnName("Media_In_Blog_U");
            entity.Property(e => e.MediaInEmailH).HasColumnName("Media_In_Email_H");
            entity.Property(e => e.MediaInEmailU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_Email_U");
            entity.Property(e => e.MediaInFaxH).HasColumnName("Media_In_Fax_H");
            entity.Property(e => e.MediaInFaxU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_Fax_U");
            entity.Property(e => e.MediaInSmsH).HasColumnName("Media_In_SMS_H");
            entity.Property(e => e.MediaInSmsU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_SMS_U");
            entity.Property(e => e.MediaInVmailH).HasColumnName("Media_In_Vmail_H");
            entity.Property(e => e.MediaInVmailU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_Vmail_U");
            entity.Property(e => e.MediaInWebCallH).HasColumnName("Media_In_WebCall_H");
            entity.Property(e => e.MediaInWebCallU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_WebCall_U");
            entity.Property(e => e.MediaInWebChatH).HasColumnName("Media_In_WebChat_H");
            entity.Property(e => e.MediaInWebChatU)
                .HasDefaultValue(0)
                .HasColumnName("Media_In_WebChat_U");
            entity.Property(e => e.MediaOutBlog).HasColumnName("Media_Out_Blog");
            entity.Property(e => e.MediaOutEmail).HasColumnName("Media_Out_Email");
            entity.Property(e => e.MediaOutFax).HasColumnName("Media_Out_Fax");
            entity.Property(e => e.MediaOutSms).HasColumnName("Media_Out_SMS");
            entity.Property(e => e.MediaWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.MediaWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OfInCallCount).HasColumnName("OF_InCallCount");
            entity.Property(e => e.OfRdBlogIn)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_BlogIn");
            entity.Property(e => e.OfRdEmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Email");
            entity.Property(e => e.OfRdFax)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_Fax");
            entity.Property(e => e.OfRdSms)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_SMS");
            entity.Property(e => e.OfRdVmail)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_VMail");
            entity.Property(e => e.OfRdWebCall)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebCall");
            entity.Property(e => e.OfRdWebChat)
                .HasDefaultValue(0)
                .HasColumnName("OF_RD_WebChat");
            entity.Property(e => e.OnlineTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherCallCountBfwd).HasColumnName("OtherCallCountBFwd");
            entity.Property(e => e.OtherTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherTime)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherTimeMax)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OtherWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutCallCountBfwd).HasColumnName("OutCallCountBFwd");
            entity.Property(e => e.OutCallTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutWorkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutWorkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.PdcallCount).HasColumnName("PDCallCount");
            entity.Property(e => e.PdcallCountBfwd).HasColumnName("PDCallCountBFwd");
            entity.Property(e => e.ReadyTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.ReadyTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.RecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RecordID");
            entity.Property(e => e.StatusBfwd).HasColumnName("StatusBFwd");
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.WriteDbtime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("WriteDBTime");
        });

        modelBuilder.Entity<RptStaffTimeTrace>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Rpt_StaffTimeTrace");

            entity.HasIndex(e => new { e.Uid, e.Timestamp }, "IX_Rpt_StaffTimeTrace");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<RptStationTime>(entity =>
        {
            entity.HasKey(e => e.RecordId);

            entity.ToTable("Rpt_StationTime");

            entity.HasIndex(e => new { e.DeviceType, e.DeviceId, e.TimeStamp, e.Extension }, "Index_Rpt_StationTime");

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.Extension)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.InTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.InterTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTime).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.OutTalkTimeMax).HasColumnType("decimal(13, 3)");
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.WriteDbtime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("WriteDBTime");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).IsClustered(false);

            entity.ToTable("Service");

            entity.HasIndex(e => e.Cyc, "IX_Service");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.Cyc).HasDefaultValue(5);
            entity.Property(e => e.ServiceDesc).HasMaxLength(50);
        });

        modelBuilder.Entity<ServiceAcdgroup>(entity =>
        {
            entity.HasKey(e => new { e.ServiceId, e.AcdgroupId });

            entity.ToTable("Service_ACDGroup");

            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.AcdgroupId).HasColumnName("ACDGroupID");
            entity.Property(e => e.AcdgroupType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACDGroupType");
        });

        modelBuilder.Entity<ServiceReport>(entity =>
        {
            entity.HasKey(e => e.ServiceId);

            entity.ToTable("Service_Report");

            entity.Property(e => e.ServiceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ServiceID");
            entity.Property(e => e.IsVaild)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ServiceName).HasMaxLength(200);
        });

        modelBuilder.Entity<SfAppointment>(entity =>
        {
            entity.HasKey(e => e.ApptId).HasName("PK__SF_Appoi__B9B1A5170CEA76CB");

            entity.ToTable("SF_Appointment");

            entity.Property(e => e.ApptId).HasColumnName("Appt_Id");
            entity.Property(e => e.ApptDate).HasColumnName("Appt_Date");
            entity.Property(e => e.ApptKeep).HasColumnName("Appt_Keep");
            entity.Property(e => e.ApptNewSub)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Appt_New_Sub");
            entity.Property(e => e.ApptSpec)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Appt_Spec");
            entity.Property(e => e.ApptSubSpec)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Appt_SubSpec");
            entity.Property(e => e.IsUch).HasColumnName("Is_UCH");
            entity.Property(e => e.NonHospital)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Non_Hospital");
            entity.Property(e => e.ParentCaseId)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Parent_Case_Id");
        });

        modelBuilder.Entity<SfCase>(entity =>
        {
            entity.HasKey(e => e.CaseId).HasName("PK__SF_Case__D062FC65E8D50E70");

            entity.ToTable("SF_Case");

            entity.Property(e => e.CaseId).HasColumnName("Case_Id");
            entity.Property(e => e.CaseStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Case_Status");
            entity.Property(e => e.CreatedById)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_ID");
            entity.Property(e => e.CreatedByName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CreatedBy_Name");
            entity.Property(e => e.CreationDateTime).HasColumnType("datetime");
            entity.Property(e => e.DocNumOfDay)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Doc_NumOfDay");
            entity.Property(e => e.DocOriginalPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Doc_OriginalPath");
            entity.Property(e => e.DocWithCodePath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Doc_withCodePath");
            entity.Property(e => e.DrCategory)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Dr_Category");
            entity.Property(e => e.DrDesignedDate).HasColumnName("Dr_DesignedDate");
            entity.Property(e => e.DrInfo)
                .IsUnicode(false)
                .HasColumnName("Dr_Info");
            entity.Property(e => e.DrNumOfWeek).HasColumnName("Dr_NumOfWeek");
            entity.Property(e => e.DrSpec)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Dr_Spec");
            entity.Property(e => e.DrSubSpec)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Dr_SubSpec");
            entity.Property(e => e.IsOnsite).HasColumnName("Is_Onsite");
            entity.Property(e => e.NurseCategory)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Nurse_Category");
            entity.Property(e => e.NurseDesignedSpec)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Nurse_DesignedSpec");
            entity.Property(e => e.NurseInfo)
                .IsUnicode(false)
                .HasColumnName("Nurse_Info");
            entity.Property(e => e.NurseNumOfWeek).HasColumnName("Nurse_NumOfWeek");
            entity.Property(e => e.NurseSelectedDate).HasColumnName("Nurse_SelectedDate");
            entity.Property(e => e.NurseSpec)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Nurse_Spec");
            entity.Property(e => e.NurseSubSpec)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Nurse_SubSpec");
            entity.Property(e => e.PatientAge)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Patient_Age");
            entity.Property(e => e.PatientGender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("Patient_Gender");
            entity.Property(e => e.PatientHkid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Patient_HKID");
            entity.Property(e => e.PatientMrn)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Patient_MRN");
            entity.Property(e => e.PatientName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Patient_Name");
            entity.Property(e => e.PatientSopd)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Patient_SOPD");
            entity.Property(e => e.ReferSpecialty)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SfTriageControl>(entity =>
        {
            entity.HasKey(e => e.ClinicSpecialty).HasName("PK__SF_Triag__AB5BCDA4FDFE63E2");

            entity.ToTable("SF_TriageControl");

            entity.Property(e => e.ClinicSpecialty)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Clinic_Specialty");
        });

        modelBuilder.Entity<SlaChangeLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SLA_ChangeLog");

            entity.Property(e => e.RecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RecordID");
            entity.Property(e => e.Sla01).HasColumnName("SLA01");
            entity.Property(e => e.Sla02).HasColumnName("SLA02");
            entity.Property(e => e.Sla03).HasColumnName("SLA03");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<SocialChat>(entity =>
        {
            entity.ToTable("SocialChat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FromNo)
                .HasMaxLength(64)
                .HasColumnName("fromNo");
            entity.Property(e => e.Message).HasMaxLength(128);
            entity.Property(e => e.Subject).HasMaxLength(128);
            entity.Property(e => e.TicketId)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("TicketID");
            entity.Property(e => e.ToNo).HasMaxLength(64);
        });

        modelBuilder.Entity<SpaceUsage>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("SpaceUsage");

            entity.HasIndex(e => new { e.RpDate, e.TableId }, "IX_SpaceUsage");

            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.RpDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("RP_Date");
            entity.Property(e => e.TableId).HasColumnName("TableID");
        });

        modelBuilder.Entity<SpaceUsageTable>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.Uid, "IX_SpaceUsageTables").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<StationUsage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StationUsage");

            entity.HasIndex(e => new { e.RpDate, e.DeviceType, e.DeviceId }, "IX_StationUsage");

            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.RpDate)
                .HasColumnType("datetime")
                .HasColumnName("RP_Date");
        });

        modelBuilder.Entity<TblTimeRange>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblTimeRange");

            entity.Property(e => e.AutoId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AutoID");
            entity.Property(e => e.TimeRange)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrunkStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TrunkStatus");

            entity.HasIndex(e => e.TimeStamp, "IX_TrunkStatus");

            entity.HasIndex(e => new { e.Duration, e.TimeStamp }, "IX_TrunkStatus_1").IsDescending(true, false);

            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Time_Stamp");
        });

        modelBuilder.Entity<TrunkUsage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TrunkUsage");

            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.Inbound).HasDefaultValue(0);
            entity.Property(e => e.Outbound).HasDefaultValue(0);
            entity.Property(e => e.RpDate)
                .HasColumnType("datetime")
                .HasColumnName("RP_Date");
        });

        modelBuilder.Entity<Videolog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Videolog");

            entity.HasIndex(e => e.CallId, "IX_Videolog");

            entity.HasIndex(e => e.TimeStamp, "IX_Videolog_1");

            entity.Property(e => e.BackupDate).HasColumnType("datetime");
            entity.Property(e => e.BackupLabel).HasMaxLength(64);
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.FileSize).HasDefaultValue(0);
            entity.Property(e => e.Filepath).HasMaxLength(255);
            entity.Property(e => e.RestoreKey).HasMaxLength(255);
            entity.Property(e => e.SerialId).HasColumnName("SerialID");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");
            entity.Property(e => e.ZipFileFolder).HasMaxLength(255);
            entity.Property(e => e.ZipPassword).HasMaxLength(255);
        });

        modelBuilder.Entity<VoiceContent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VoiceContent");

            entity.HasIndex(e => new { e.CallId, e.Seq }, "NonClusteredIndex-20220315-110714");

            entity.Property(e => e.Business)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.Entity).HasMaxLength(100);
            entity.Property(e => e.Intention).HasMaxLength(50);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpeakerId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SpeakerID");
            entity.Property(e => e.SpeakerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpeakerType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.VoiceLogName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VoicelogId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VoicelogID");
        });

        modelBuilder.Entity<Voicelog>(entity =>
        {
            entity.HasKey(e => new { e.CallId, e.SerialId });

            entity.ToTable("Voicelog");

            entity.HasIndex(e => e.CallId, "IX_Voicelog");

            entity.HasIndex(e => e.TimeStamp, "IX_Voicelog_1");

            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.SerialId).HasColumnName("SerialID");
            entity.Property(e => e.AgentName).HasMaxLength(64);
            entity.Property(e => e.BackupDate).HasColumnType("datetime");
            entity.Property(e => e.BackupLabel).HasMaxLength(64);
            entity.Property(e => e.Content).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.FileSize).HasDefaultValue(0);
            entity.Property(e => e.Filepath).HasMaxLength(255);
            entity.Property(e => e.RestoreKey).HasMaxLength(255);
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");
            entity.Property(e => e.ZipFileFolder).HasMaxLength(255);
            entity.Property(e => e.ZipPassword).HasMaxLength(255);
        });

        modelBuilder.Entity<Voicemail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Voicemail");

            entity.HasIndex(e => e.CallId, "IX_Voicemail");

            entity.HasIndex(e => e.TimeStamp, "IX_Voicemail_1");

            entity.Property(e => e.BackupDate).HasColumnType("datetime");
            entity.Property(e => e.BackupLabel).HasMaxLength(64);
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.Filepath).HasMaxLength(255);
            entity.Property(e => e.RestoreKey).HasMaxLength(255);
            entity.Property(e => e.TelNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("Time_stamp");
            entity.Property(e => e.Vmduration).HasColumnName("VMDuration");
            entity.Property(e => e.ZipFileFolder).HasMaxLength(255);
            entity.Property(e => e.ZipPassword).HasMaxLength(255);
        });

        modelBuilder.Entity<VwAgentsInCall>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_AgentsInCall");

            entity.Property(e => e.CallId).HasColumnName("CallID");
        });

        modelBuilder.Entity<VwFullVoiceLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_FullVoiceLog");

            entity.Property(e => e.AgentList)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Ani)
                .HasMaxLength(64)
                .HasColumnName("ANI");
            entity.Property(e => e.Begintime).HasColumnType("datetime");
            entity.Property(e => e.CallId).HasColumnName("CallID");
            entity.Property(e => e.CallTypeEx)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Dnis)
                .HasMaxLength(64)
                .HasColumnName("DNIS");
            entity.Property(e => e.NextCallId).HasColumnName("NextCallID");
            entity.Property(e => e.PrevCallId).HasColumnName("PrevCallID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
        });

        modelBuilder.Entity<VwPhonesInCall>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_PhonesInCall");

            entity.Property(e => e.CallId).HasColumnName("CallID");
        });

        modelBuilder.Entity<VwVoiceLogPath>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_VoiceLogPath");

            entity.Property(e => e.CallId).HasColumnName("CallID");
        });

        modelBuilder.Entity<WebCall>(entity =>
        {
            entity.ToTable("WebCall");

            entity.HasIndex(e => new { e.Status, e.Date }, "StatusDate_WebCall");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.FromNo).HasMaxLength(50);
            entity.Property(e => e.Message).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValue(0);
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.ToNo).HasMaxLength(50);
        });

        modelBuilder.Entity<WebChat>(entity =>
        {
            entity.ToTable("WebChat");

            entity.HasIndex(e => e.Status, "Status_WebChat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FromNo)
                .HasMaxLength(64)
                .HasColumnName("fromNo");
            entity.Property(e => e.Message).HasMaxLength(128);
            entity.Property(e => e.Subject).HasMaxLength(128);
            entity.Property(e => e.TicketId)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("TicketID");
            entity.Property(e => e.ToNo).HasMaxLength(64);
        });

        modelBuilder.Entity<WebRptType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WebRpt_Type");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.TypeStr).HasMaxLength(3);
            entity.Property(e => e.Uid).HasColumnName("UID");
        });

        modelBuilder.Entity<WiseBlackListPhone>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("wiseBlackListPhone");

            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<WiseDbChangeLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WiseDB_ChangeLog");

            entity.Property(e => e.RecordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("RecordID");
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Version).HasMaxLength(50);
        });

        modelBuilder.Entity<WiseMediaAcd>(entity =>
        {
            entity.HasKey(e => e.Logid);

            entity.ToTable("WiseMediaACD");

            entity.HasIndex(e => new { e.Calltypeid, e.AssignAgent }, "IX_WiseMediaACD");

            entity.HasIndex(e => e.AssignAgent, "IX_WiseMediaACD_1");

            entity.Property(e => e.AlertDatetime).HasColumnType("datetime");
            entity.Property(e => e.Ani)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ANI");
            entity.Property(e => e.ArriveDatetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AssignAcdgroup).HasColumnName("AssignACDgroup");
            entity.Property(e => e.Contactno)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.CreateDatetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dnis)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("DNIS");
            entity.Property(e => e.Filepath)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.Ivrsdata)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.ReadDatetime).HasColumnType("datetime");
            entity.Property(e => e.Summary)
                .HasMaxLength(255)
                .HasDefaultValue("");
        });

        modelBuilder.Entity<WiseMediaFile>(entity =>
        {
            entity.HasKey(e => e.Logid);

            entity.ToTable("WiseMediaFile");

            entity.HasIndex(e => e.Callid, "IX_WiseMediaFile");

            entity.Property(e => e.Ani)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("ANI");
            entity.Property(e => e.ArriveDatetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.BackupDatetime).HasColumnType("datetime");
            entity.Property(e => e.BackupFilename).HasMaxLength(255);
            entity.Property(e => e.CreateAgent).HasMaxLength(25);
            entity.Property(e => e.CreateDatetime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dnis)
                .HasMaxLength(50)
                .HasDefaultValue("")
                .HasColumnName("DNIS");
            entity.Property(e => e.Filepath)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.Ivrsdata)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.Serialid).HasDefaultValue(0);
        });

        modelBuilder.Entity<WiseWallBoardMcid>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("wiseWallBoardMCID");

            entity.Property(e => e.Cid).HasColumnName("CID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WiseWallBoardParameter>(entity =>
        {
            entity.HasKey(e => e.Parameter).HasName("PK_www");

            entity.ToTable("wiseWallBoardParameter");

            entity.Property(e => e.Parameter)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("parameter");
            entity.Property(e => e.PValue)
                .HasMaxLength(100)
                .HasColumnName("pValue");
        });

        modelBuilder.Entity<WiseWallBoardRpt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("wiseWallBoardRpt");

            entity.Property(e => e.BHandled).HasColumnName("bHandled");
            entity.Property(e => e.Mcid).HasColumnName("MCID");
            entity.Property(e => e.ServId).HasColumnName("ServID");
        });

        modelBuilder.Entity<WiseWbacdrpt>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("wiseWBACDRpt");

            entity.Property(e => e.AcdgrpId).HasColumnName("ACDGrpID");
            entity.Property(e => e.WaitTime)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkingTime>(entity =>
        {
            entity.HasKey(e => new { e.CampaignId, e.StepId });

            entity.ToTable("WorkingTime");

            entity.Property(e => e.CampaignId).HasColumnName("CampaignID");
            entity.Property(e => e.StepId).HasColumnName("StepID");
        });

        modelBuilder.Entity<SP_Dashboard_Data_Agent_Result>(entity =>
        {
            entity.HasKey(e => new { e.agent_id });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
