using DemoTypingTest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoTypingTest.Data
{
    public class DemoTypingTestDbContext : IdentityDbContext<User>
    {
        public DemoTypingTestDbContext(DbContextOptions<DemoTypingTestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Test> Tests { get; set; }
    }
}
