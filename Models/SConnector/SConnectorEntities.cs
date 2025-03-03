using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WisePBX.NET8.Models.Wise;

namespace WisePBX.NET8.Models.SConnector;

public partial class SConnectorEntities : DbContext
{
    public SConnectorEntities()
    {
    }

    public SConnectorEntities(DbContextOptions<SConnectorEntities> options)
        : base(options)
    {
    }
    public virtual DbSet<SCRM_CannedFile> SCRM_CannedFiles { get; set; }

    public virtual DbSet<SCRM_CannedMsg> SCRM_CannedMsgs { get; set; }

    public virtual DbSet<SC_MsgHistory> SC_MsgHistories { get; set; }

    public virtual DbSet<SC_OfflineForm> SC_OfflineForms { get; set; }

    public virtual DbSet<SC_OnlineForm> SC_OnlineForms { get; set; }

    public virtual DbSet<SC_Ticket> SC_Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=172.17.7.40;Database=SConnector;Integrated Security=false;User ID=sa;Password=+Epro_Demo+;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SCRM_CannedFile>(entity =>
        {
            entity.HasKey(e => e.FileId);

            entity.ToTable("SCRM_CannedFile");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.FileName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FilePath)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.FileUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<SCRM_CannedMsg>(entity =>
        {
            entity.HasKey(e => e.MsgID);

            entity.ToTable("SCRM_CannedMsg");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Message).HasMaxLength(1000);
            entity.Property(e => e.UpdateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<SC_MsgHistory>(entity =>
        {
            entity.HasKey(e => new { e.ticket_id, e.msg_id, e.index_no });

            entity.ToTable("SC_MsgHistory");

            entity.Property(e => e.msg_id).HasMaxLength(100);
            entity.Property(e => e.complete_date).HasMaxLength(50);
            entity.Property(e => e.enduser_id).HasMaxLength(100);
            entity.Property(e => e.fb_comment_id).HasMaxLength(50);
            entity.Property(e => e.msg_type).HasMaxLength(50);
            entity.Property(e => e.nick_name).HasMaxLength(50);
            entity.Property(e => e.sc_comment_id).HasMaxLength(50);
            entity.Property(e => e.sc_post_id).HasMaxLength(50);
            entity.Property(e => e.sender).HasMaxLength(50);
            entity.Property(e => e.sent_time).HasMaxLength(50);
            entity.Property(e => e.ticket_chat_id).HasMaxLength(100);
        });

        modelBuilder.Entity<SC_OfflineForm>(entity =>
        {
            entity.HasKey(e => new { e.ticket_id, e.field_id });

            entity.ToTable("SC_OfflineForm");

            entity.Property(e => e.field_name).HasMaxLength(50);
            entity.Property(e => e.field_value).HasMaxLength(50);
            entity.Property(e => e.sent_time).HasMaxLength(50);
        });

        modelBuilder.Entity<SC_OnlineForm>(entity =>
        {
            entity.HasKey(e => new { e.ticket_id, e.field_id });

            entity.ToTable("SC_OnlineForm");

            entity.Property(e => e.field_key).HasMaxLength(50);
        });

        modelBuilder.Entity<SC_Ticket>(entity =>
        {
            entity.HasKey(e => e.ticket_id).HasName("PK_Ticket");

            entity.ToTable("SC_Ticket");

            entity.HasIndex(e => e.start_time, "IK_SC_Ticket-start_time");

            entity.Property(e => e.ticket_id).ValueGeneratedNever();
            entity.Property(e => e.assign_to).HasMaxLength(50);
            entity.Property(e => e.category_name).HasMaxLength(50);
            entity.Property(e => e.company_code).HasMaxLength(50);
            entity.Property(e => e.cs_member).HasMaxLength(200);
            entity.Property(e => e.enduser_id).HasMaxLength(50);
            entity.Property(e => e.entry).HasMaxLength(50);
            entity.Property(e => e.last_active_time).HasMaxLength(50);
            entity.Property(e => e.nick_name).HasMaxLength(50);
            entity.Property(e => e.rating).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.start_time).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
