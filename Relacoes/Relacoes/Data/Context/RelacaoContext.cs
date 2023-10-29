using Microsoft.EntityFrameworkCore;
using Relacoes.Models;

namespace Relacoes.Data.Context
{
    public class RelacaoContext : DbContext
    {
        public RelacaoContext(DbContextOptions<RelacaoContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

        }
    }
}
