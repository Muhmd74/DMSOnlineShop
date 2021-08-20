using System.Reflection;
using DMSOnlineStore.Core.Models;
using DMSOnlineStore.Infrastructure.Data.ModelConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DMSOnlineStore.Infrastructure.Data.Tools
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionOptions.Create(), x => x.MigrationsHistoryTable("Assembly"));
            base.OnConfiguring(optionsBuilder);
        }

         public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
