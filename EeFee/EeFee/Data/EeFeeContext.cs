    using EeFee.Models;
using Microsoft.EntityFrameworkCore;

namespace EeFee.Data
{
    public class EeFeeContext : DbContext
    {
        public EeFeeContext(DbContextOptions<EeFeeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Position)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PositionId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
