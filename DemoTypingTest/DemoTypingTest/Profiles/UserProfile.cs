using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;

namespace DemoTypingTest.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, ApplicationUser>();
            
            CreateMap<ApplicationUser, ReadApplicationUserDto>()
                .ReverseMap();
        }
    }
}
