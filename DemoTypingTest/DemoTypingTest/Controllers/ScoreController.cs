using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoTypingTest.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly ScoreService _scoreService;

        public ScoreController(ScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet("user/all")]
        public async Task<IActionResult> GetAllUserScore([FromQuery] string userId)
        {
            return Ok(await _scoreService.GetAllUserScores(userId));
        }

        [HttpGet("user/best")]
        public async Task<IActionResult> GetBestUserScore([FromQuery] string difficulty,
            [FromQuery] string userId)
        {
            return Ok(await _scoreService.GetBestUserScores(difficulty, userId));
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopScores([FromQuery] string difficulty)
        {
            return Ok(await _scoreService.GetTopScores(difficulty));
        }
    }
}
