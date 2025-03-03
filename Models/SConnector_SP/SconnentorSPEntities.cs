using Microsoft.EntityFrameworkCore;

namespace WisePBX.NET8.Models.SConnector_SP
{
    public partial class SConnectorSPEntities : DbContext
    {
        public SConnectorSPEntities()
        {
        }

        public SConnectorSPEntities(DbContextOptions<SConnectorSPEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<get_fb_comment_Result> get_fb_comment_Results { get; set; }
        public IEnumerable<get_fb_comment_Result> get_fb_comment(long ticket_id, string above_msg_id = "", string after_msg_id = "")
        {
            return this.get_fb_comment_Results
                .FromSqlInterpolated($"[dbo].[get_fb_comment] {ticket_id},{above_msg_id},{after_msg_id}")
                .ToArray();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=172.17.7.40;Database=SConnector;Integrated Security=false;User ID=sa;Password=+Epro_Demo+;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<get_fb_comment_Result>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
