using DemoTypingTest.Data;
using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using DemoTypingTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoTypingTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TestService _testService;

        public TestController(TestService testService)
        {
            _testService = testService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTestDto createTestDto,
            [FromQuery] string userId)
        {
            var test = await _testService.Create(createTestDto, userId);
            return CreatedAtAction(nameof(Create), test.Id, test);
        }
    }
}
