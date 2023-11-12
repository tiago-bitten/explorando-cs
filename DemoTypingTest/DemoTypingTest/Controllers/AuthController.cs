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

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInDto dto)
        {
            return Ok(await _authService.SignIn(dto));
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(CreateUserDto dto)
        {
            var user = await _authService.SignUp(dto);
            return CreatedAtAction(nameof(SignUp), user.Id, user);
        }
    }
}
