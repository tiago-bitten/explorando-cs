using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using DemoTypingTest.Repositories;

namespace DemoTypingTest.Services
{
    public class TestService
    {
        private readonly ApplicationUserRepository _applicationUserRepository;
        private readonly TestRepository _testRepository;
        private readonly IMapper _mapper;

        public TestService(TestRepository testRepository, IMapper mapper, ApplicationUserRepository applicationUserRepository)
        {
            _testRepository = testRepository;
            _mapper = mapper;
            _applicationUserRepository = applicationUserRepository;
        }

        public async Task<ReadTestDto> Create(CreateTestDto dto)
        {
            var test = _mapper.Map<Test>(dto);

            test.Id = Guid.NewGuid().ToString();

            var user = await _applicationUserRepository.FindById(dto.UserId);
            if (user == null)
            {
                throw new ApplicationException("User not found");
            }

            test.User = user;

            await _testRepository.Create(test);

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
