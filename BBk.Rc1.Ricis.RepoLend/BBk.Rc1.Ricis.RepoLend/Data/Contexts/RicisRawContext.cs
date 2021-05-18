using BBk.Rc1.Ricis.RepoLend.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace BBk.Rc1.Ricis.RepoLend.Data.Contexts
{
    public partial class RicisRawContext : DbContext
    {
        public RicisRawContext()
        {
        }

        public RicisRawContext(DbContextOptions<RicisRawContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RepoLendIO> RepoLendIO { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=AstericsTestRaw210407;Trusted_Connection=True;");
            }
        }
    }
}
