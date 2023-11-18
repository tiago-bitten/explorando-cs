using AutoMapper;
using UploadImage.Dtos;
using UploadImage.Models;

namespace UploadImage.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ReadProductDto>();
            CreateMap<CreateProductDto, Product>();
        }
    }
}
