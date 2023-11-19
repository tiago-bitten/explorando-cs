using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using UploadImage.Dtos;
using UploadImage.Models;
using UploadImage.Repositories;

namespace UploadImage.Services
{
    public class ProductImagesService
    {
        private readonly ProductImagesRepository _productImagesRepository;
        private readonly GoogleDriveService _googleDriveService;
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductImagesService(ProductImagesRepository productImagesRepository,
            GoogleDriveService googleDriveService,
            ProductService productService,
            IMapper mapper)
        {
            _productImagesRepository = productImagesRepository;
            _googleDriveService = googleDriveService;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ReadProductImagesDto> Upload(IFormFile file, string productId)
        {
            if (file == null)
            {
                throw new ApplicationException("File is null");
            }

            var product = await _productService.GetProductById(productId);
            if (product == null)
            {
                throw new ApplicationException("Product not found");
            }

            if (!IsImage(ExtractExtension(file.FileName)))
            {
                throw new ApplicationException("File is not an image");
            }
            var fileName = ExtractFileName(file.FileName) + "___=)___" + Guid.NewGuid().ToString() + ExtractExtension(file.FileName);

            var uploadedFile = _googleDriveService.Upload(file, fileName);

            var productImage = new ProductImages()
            {
                Id = Guid.NewGuid().ToString(),
                Name = fileName,
                Key = uploadedFile.Id,
                ProductId = productId,
            };

            await _productImagesRepository.AddProductImage(productImage);

            return _mapper.Map<ReadProductImagesDto>(productImage);
        }

        public Task<byte[]> Recover(string imageKey)
        {
            return _googleDriveService.Recover(imageKey);
        }

        private string ExtractExtension(string fileName)
        {
            return fileName.Substring(fileName.LastIndexOf('.'));
        }

        private string ExtractFileName(string fileName)
        {
            return fileName[..fileName.LastIndexOf('.')];
        }

        private Boolean IsImage(string extension)
        {
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png";
        }
    }
}
