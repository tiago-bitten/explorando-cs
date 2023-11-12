using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;

namespace DemoTypingTest.Profiles
{
    public class ScoreProfile : Profile
    {
        public ScoreProfile()
        {
            CreateMap<CreateScoreDto, Score>();

            CreateMap<Score, ReadScoreDto>()
                .ReverseMap();
        }
    }
}
