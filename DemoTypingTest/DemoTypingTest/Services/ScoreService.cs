using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using DemoTypingTest.Repositories;

namespace DemoTypingTest.Services
{
    public class ScoreService
    {
        private readonly ScoreRepository _scoreRepository;
        private readonly TestService _testService;
        private readonly IMapper _mapper;

        public ScoreService(ScoreRepository scoreRepository, TestService testService,IMapper mapper)
        {
            _scoreRepository = scoreRepository;
            _testService = testService;
            _mapper = mapper;
        }

        public async Task<ReadScoreDto> Create(CreateScoreDto dto)
        {
            var score = _mapper.Map<Score>(dto);

            score.Id = Guid.NewGuid().ToString();

            var testDto = await _testService.FindById(dto.TestId);
            var test = _mapper.Map<Test>(testDto);

            score.TestId = test.Id;

            await _scoreRepository.Create(score);

            return _mapper.Map<ReadScoreDto>(score);
        }
    }
}
