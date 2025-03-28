using Microsoft.EntityFrameworkCore;

namespace WisePBX.NET8.Models.SConnector_SP
{
    public partial class SConnectorSPEntities : DbContext
    {
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
