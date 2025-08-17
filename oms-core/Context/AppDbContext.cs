using Microsoft.EntityFrameworkCore;
using oms_core.Entity;
using oms_core.Interface.Config;

namespace oms_core.Context
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options, IDbConfig dbConfig)
        : DbContext(options)
    {
        private readonly IDbConfig _dbConfig = dbConfig;

        public DbSet<User> Users { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _dbConfig?.GetConnectionString();
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(o => o.Status).HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
