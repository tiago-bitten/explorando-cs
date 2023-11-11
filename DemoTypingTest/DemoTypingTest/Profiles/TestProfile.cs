using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;

namespace DemoTypingTest.Profiles
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<CreateTestDto, Test>();
            CreateMap<Test, ReadTestDto>()
                .ForMember(dto => dto.User,
                opt => opt.MapFrom(test => test.User));
        }
    }
}
