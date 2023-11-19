using AutoMapper;
using UploadImage.Dtos;
using UploadImage.Models;
using UploadImage.Repositories;

namespace UploadImage.Services
{
    public class ProductService
    {
        private readonly IMapper _mapper;
        private readonly ProductRepository _productRepository;

        public ProductService(IMapper mapper, ProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ReadProductDto> Create(CreateProductDto dto)
        {
            Product product = _mapper.Map<Product>(dto);

            product.Id = Guid.NewGuid().ToString();
            await _productRepository.AddProduct(product);

            return _mapper.Map<ReadProductDto>(product);
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _productRepository.GetProductById(id);
        }
    }
}
