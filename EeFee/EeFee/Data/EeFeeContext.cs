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
            modelBuilder.Entity<Position>()
                .HasMany(p => p.Users)
                .WithOne(u => u.Position)
                .HasForeignKey(u => u.PositionId)
                .HasPrincipalKey(p => p.Id);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
