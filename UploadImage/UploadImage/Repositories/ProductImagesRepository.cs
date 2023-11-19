using UploadImage.Data;
using UploadImage.Models;

namespace UploadImage.Repositories
{
    public class ProductImagesRepository
    {
        private readonly UploadImageDbContext _context;

        public ProductImagesRepository(UploadImageDbContext context)
        {
            _context = context;
        }

        public async Task AddProductImage(ProductImages productImage)
        {
            await _context.ProductImages.AddAsync(productImage);
            await _context.SaveChangesAsync();
        }
    }
}
