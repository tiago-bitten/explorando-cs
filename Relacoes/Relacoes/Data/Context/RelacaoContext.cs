using Microsoft.EntityFrameworkCore;

namespace Relacoes.Data.Context
{
    public class RelacaoContext : DbContext
    {
        public RelacaoContext(DbContextOptions<RelacaoContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
