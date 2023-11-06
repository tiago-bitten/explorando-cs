using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoTypingTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly DemoTypingTestContext _context;

        public TestController(DemoTypingTestContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateTest([FromBody] CreateTestDto createTestDto)
        {
            var test = new Test
            {
                TextTest = createTestDto.TextTest,
                TotalWords = int.Parse(createTestDto.TotalWords),
                TotalCharacters = int.Parse(createTestDto.TotalCharacters),
                IncorrectWords = int.Parse(createTestDto.IncorrectWords),
                IncorrectCharacters = int.Parse(createTestDto.IncorrectCharacters),
                Time = int.Parse(createTestDto.Time),
                UserId = createTestDto.UserId
            };
            _context.Tests
            _context.SaveChanges();
            return Ok();
        }
    }
}
