﻿using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using DemoTypingTest.Repositories;

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

        public async Task<ReadTestDto> Create(CreateTestDto dto, string userId)
        {
            var test = _mapper.Map<Test>(dto);

            test.Id = Guid.NewGuid().ToString();

            var userDto = await _applicationUserService.FindById(userId);
            var user = _mapper.Map<ApplicationUser>(userDto);

            test.UserId = user.Id;

            await _testRepository.Create(test);
            await _scoreService.Create(test);

            return _mapper.Map<ReadTestDto>(test);
        }

        public async Task<ReadTestDto> FindById(string id)
        {
            var test = await _testRepository.FindById(id);
            if (test == null)
            {
                throw new ApplicationException("Test not found");
            }

            return _mapper.Map<ReadTestDto>(test);
        }
    }
}
