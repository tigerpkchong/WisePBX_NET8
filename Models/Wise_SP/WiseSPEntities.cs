using Microsoft.EntityFrameworkCore;

namespace WisePBX.NET8.Models.Wise_SP
{
    public partial class WiseSPEntities : DbContext
    {
        public WiseSPEntities(DbContextOptions<WiseSPEntities> options)
            : base(options)
        {
        }
        public virtual DbSet<SP_wallboard_count_Result> SP_wallboard_count_Results { get; set; }

        public IEnumerable<SP_wallboard_count_Result> SP_wallboard_count(DateTime report_date, string? service_id = null)
        {
            return this.SP_wallboard_count_Results
                .FromSqlInterpolated($"[dbo].[SP_wallboard_count] {report_date},{service_id}")
                .ToArray();
        }
        public virtual DbSet<SP_Dashboard_Data_Result> SP_Dashboard_Data_Results { get; set; }
        public IEnumerable<SP_Dashboard_Data_Result> SP_Dashboard_Data(string? servicelist = "")
        {
            return this.SP_Dashboard_Data_Results
                .FromSqlInterpolated($"[dbo].[SP_Dashboard_Data] {servicelist}")
                .ToArray();
        }
        public virtual DbSet<SP_Dashboard_Data_Agent_Result> SP_Dashboard_Data_Agent_Results { get; set; }
        public IEnumerable<SP_Dashboard_Data_Result> SP_Dashboard_Data_Agent(int days_before, string? servicelist = "")
        {
            return this.SP_Dashboard_Data_Results
                .FromSqlInterpolated($"[dbo].[SP_Dashboard_Data_Agent] {days_before}, {servicelist}")
                .ToArray();
        }
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

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
