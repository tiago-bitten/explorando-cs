using AutoMapper;
using UploadImage.Dtos;
using UploadImage.Models;

namespace UploadImage.Mappers
{
    public class ProductImagesProfile : Profile
    {
        public ProductImagesProfile()
        {
            CreateMap<CreateProductImagesDto, ProductImages>();

            CreateMap<ProductImages, ReadProductImagesDto>()
                .ForMember(dest => dest.Product,
                opt => opt.MapFrom(src => src.Product));
        }
    }
}
