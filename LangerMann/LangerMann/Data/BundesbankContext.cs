using LangerMann.Models;
using Microsoft.EntityFrameworkCore;


namespace LangerMann.Data
{
    public class BundesbankContext : DbContext
    {
        public BundesbankContext (DbContextOptions<BundesbankContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Tblpersonen { get; set; }
    }
}
