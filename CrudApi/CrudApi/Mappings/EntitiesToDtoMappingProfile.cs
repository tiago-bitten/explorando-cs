using AutoMapper;
using CrudApi.DTOs;
using CrudApi.Models;

namespace CrudApi.Mappings
{
    public class EntitiesToDtoMappingProfile : Profile
    {
        public EntitiesToDtoMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
        }
    }
}
