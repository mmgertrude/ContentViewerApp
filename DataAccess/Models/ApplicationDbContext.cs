using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
   public class ApplicationDbContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>().ToTable("Pages");
            /*
            modelBuilder.Entity<SystemSetting>()
           .HasIndex(b => b.Code)
           .IsUnique();
           */
        }

    }
}
