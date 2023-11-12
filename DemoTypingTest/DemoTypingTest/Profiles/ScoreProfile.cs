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
                .ReverseMap();
        }
    }
}
