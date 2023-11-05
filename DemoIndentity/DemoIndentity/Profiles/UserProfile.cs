using AutoMapper;
using DemoIndentity.Data.Dtos;
using DemoIndentity.Models;

namespace DemoIndentity.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
