using Microsoft.EntityFrameworkCore;
using UploadImage.Models;

namespace UploadImage.Data
{
    public class UploadImageDbContext : DbContext
    {
        public UploadImageDbContext(DbContextOptions<UploadImageDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
    }
}
