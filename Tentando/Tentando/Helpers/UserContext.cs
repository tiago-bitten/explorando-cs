using Microsoft.EntityFrameworkCore;
using Tentando.Models;

namespace Tentando.Helpers
{
    public class UserContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public UserContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresConnection"));
        }

        public DbSet<User> Users { get; set; }
    }
}
