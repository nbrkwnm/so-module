using System;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using SOModule.Domain.Models;

namespace SOModule.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<ServiceOrder> ServiceOrders { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(c => c.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}