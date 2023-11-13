using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Exceptions;
using DemoTypingTest.Models;
using DemoTypingTest.Repositories;
using DemoTypingTest.Utils;

namespace DemoTypingTest.Services
{
    public class TestService
    {
        private readonly TestRepository _testRepository;
        private readonly ApplicationUserService _applicationUserService;
        private readonly ScoreService _scoreService;
        private readonly IMapper _mapper;

        public TestService(TestRepository testRepository, IMapper mapper,
            ApplicationUserService applicationUserService, ScoreService scoreService)
        {
            _testRepository = testRepository;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
            _scoreService = scoreService;
        }

        public async Task<ReadScoreDto> Create(CreateTestDto dto, string userId)
        {
            var test = _mapper.Map<Test>(dto);

            test.Id = Guid.NewGuid().ToString();

            var userDto = await _applicationUserService.FindById(userId);
            test.UserId = userDto.Id;

            await _testRepository.Create(test);
            var score = await _scoreService.Create(test);

            return score;
        }

        public async Task<ReadTestDto> FindById(string id)
        {
            var test = await _testRepository.FindById(id);
            return _mapper.Map<ReadTestDto>(test);
        }

        public ReadTestGeneratedDto GetTest(string testDifficulty)
        {
            return testDifficulty.ToUpper() switch
            {
                "SHORT" => GetShortTest(),
                "MEDIUM" => GetMediumTest(),
                "LONG" => GetLongTest(),
                _ => throw new NotFoundException("Test difficulty not found"),
            };
        }

        private ReadTestGeneratedDto GetShortTest()
        {
            return new ReadTestGeneratedDto()
            {
                Words = TestUtil.GenerateTest(5, 3, 2)
            };
        }

        private ReadTestGeneratedDto GetMediumTest()
        {
            return new ReadTestGeneratedDto()
            {
                Words = TestUtil.GenerateTest(4, 7, 4)
            };
        }

        private ReadTestGeneratedDto GetLongTest()
        {
            return new ReadTestGeneratedDto()
            {
                Words = TestUtil.GenerateTest(4, 9, 7)
            };
        }
    }
}
