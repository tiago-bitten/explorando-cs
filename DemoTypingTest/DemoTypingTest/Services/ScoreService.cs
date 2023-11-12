using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using DemoTypingTest.Repositories;

namespace DemoTypingTest.Services
{
    public class ScoreService
    {
        private readonly ScoreRepository _scoreRepository;
        private readonly IMapper _mapper;

        public ScoreService(ScoreRepository scoreRepository, IMapper mapper)
        {
            _scoreRepository = scoreRepository;
            _mapper = mapper;
        }

        public async Task Create(Test test)
        {
            var score = new Score()
            {
                Id = Guid.NewGuid().ToString(),
                Accuracy = CalculateAccuracy(test.TotalCharacters, test.IncorrectCharacters),
                Wpm = CalculateWpm(test.TotalWords, test.IncorrectWords, test.Time),
                TestId = test.Id,
            };

            await _scoreRepository.Create(score);
        }

        private double CalculateAccuracy(int letters, int mistakes)
        {
            return Math.Round((double)(letters - mistakes) / letters * 100, 2);
        }

        private double CalculateWpm(int words, int incorrectWords, int time)
        {
            double minutes = time / 60.0;
            return Math.Round((words - incorrectWords) / minutes, 2);
        }
    }
}
