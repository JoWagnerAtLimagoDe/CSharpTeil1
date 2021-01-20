using System;
using System.Collections.Generic;
using System.Text;
using FirstEFProject.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstEFProject.Persistence
{
    public class EntityFrameworkContext: DbContext
    {
        public DbSet<Person> PersonSet{ get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=buba;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
    }
    
}
