using DemoTypingTest.Data;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using DemoTypingTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoTypingTest.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TestService _testService;

        public TestController(TestService testService)
        {
            _testService = testService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateTest([FromBody] CreateTestDto createTestDto)
        {
            var test = await _testService.Create(createTestDto);
            return CreatedAtAction(nameof(CreateTest), test.Id, test);
        }
    }
}
