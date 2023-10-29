using AutoMapper;
using EeFee.DTOs;
using EeFee.Models;

namespace EeFee.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<User, CreateUserDTO>().ReverseMap();
        }
    }
}
