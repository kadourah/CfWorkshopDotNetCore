using System;
using Microsoft.EntityFrameworkCore;
using CfWorkshopDotNetCore.Models;

namespace CfWorkshopDotNetCore.Models
{
    public class CfWorkshopContext : DbContext
    {
        public CfWorkshopContext (DbContextOptions<CfWorkshopContext> options)
            : base(options)
        {
        }

        public DbSet<CfWorkshopDotNetCore.Models.Note> Note { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Note>().Property(b => b.Created).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        }
    }
}
