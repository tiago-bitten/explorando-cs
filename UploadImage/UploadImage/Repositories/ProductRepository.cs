using UploadImage.Data;
using UploadImage.Models;

namespace UploadImage.Repositories
{
    public class ProductRepository
    {
        private readonly UploadImageDbContext _context;

        public ProductRepository(UploadImageDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}
