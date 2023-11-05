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
    }
}
