using DemoTypingTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoTypingTest.Data
{
    public class IdentityUserDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public IdentityUserDbContext(DbContextOptions<IdentityUserDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                       
        }

        public DbSet<Test> Tests { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
