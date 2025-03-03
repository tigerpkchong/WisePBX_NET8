using Microsoft.EntityFrameworkCore;

namespace WisePBX.NET8.Models.Wise_SP
{
    public partial class WiseSPEntities : DbContext
    {
        public WiseSPEntities()
        {
        }

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=172.17.7.40;Database=Wise;Integrated Security=false;User ID=sa;Password=+Epro_Demo+;TrustServerCertificate=true;");

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
