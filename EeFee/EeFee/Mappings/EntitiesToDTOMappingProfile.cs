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
            CreateMap<User, UserDTO>()
                .ReverseMap()
                .ForMember(dto => dto.Position,
                opt => opt.MapFrom(user => user.Position));

            CreateMap<Position, CreatePositionDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>()
                .ReverseMap();
        }
    }
}
