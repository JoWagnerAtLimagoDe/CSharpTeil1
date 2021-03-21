using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebShop.Entities
{
    public partial class WebShopContext : DbContext
    {
        public WebShopContext()
        {
        }

        public WebShopContext(DbContextOptions<WebShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBestellung> TblBestellung { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=m999ricis002d;Database=CsSchulung;Trusted_Connection=True;");

//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=m999ricis002d;Database=CsSchulung;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBestellung>(entity =>
            {
                entity.ToTable("tblBestellung");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(36)
                    .ValueGeneratedNever();

                entity.Property(e => e.Produkt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rowversion)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
