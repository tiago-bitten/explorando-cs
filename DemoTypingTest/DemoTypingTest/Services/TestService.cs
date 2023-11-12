using AutoMapper;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using DemoTypingTest.Repositories;

namespace DemoTypingTest.Services
{
    public class TestService
    {
        private readonly TestRepository _testRepository;
        private readonly ApplicationUserService _applicationUserService;
        private readonly IMapper _mapper;

        public TestService(TestRepository testRepository, IMapper mapper,
            ApplicationUserService applicationUserService)
        {
            _testRepository = testRepository;
            _mapper = mapper;
            _applicationUserService = applicationUserService;
        }

        public async Task<ReadTestDto> Create(CreateTestDto dto)
        {
            var test = _mapper.Map<Test>(dto);

            test.Id = Guid.NewGuid().ToString();

            var userDto = await _applicationUserService.FindById(dto.UserId);
            var user = _mapper.Map<ApplicationUser>(userDto);

            test.UserId = user.Id;

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
