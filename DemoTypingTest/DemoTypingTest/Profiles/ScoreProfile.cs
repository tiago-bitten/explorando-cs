using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;

namespace DemoTypingTest.Profiles
{
    public class ScoreProfile : Profile
    {
        public ScoreProfile()
        {
            CreateMap<Score, ReadScoreDto>()
                .ReverseMap()
                .ForMember(dto => dto.Test,
                opt => opt.MapFrom(score => score.Test));
        }
    }
}
