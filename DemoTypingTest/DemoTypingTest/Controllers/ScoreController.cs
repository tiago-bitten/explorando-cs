using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoTypingTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly ScoreService _scoreService;

        public ScoreController(ScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create(CreateScoreDto dto)
        {
            var score = await _scoreService.Create(dto);
            return CreatedAtAction(nameof(Create), score.Id, score);
        }
    }
}
