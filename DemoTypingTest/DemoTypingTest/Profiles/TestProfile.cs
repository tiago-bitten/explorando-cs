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
                .ReverseMap()
                .ForMember(dto => dto.User,
                opt => opt.MapFrom(test => test.User))
                .ForMember(dto => dto.Score,
                opt => opt.MapFrom(test => test.Score));
        }
    }
}
