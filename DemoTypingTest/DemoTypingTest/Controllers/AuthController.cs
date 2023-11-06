using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoTypingTest.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await _authService.Login(dto));
        }
    }
}
