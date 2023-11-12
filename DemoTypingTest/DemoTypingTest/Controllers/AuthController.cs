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
        private readonly ApplicationUserService _userService;

        public AuthController(AuthService authService, ApplicationUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await _authService.Login(dto));
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var user = await _userService.Create(dto);
            return CreatedAtAction(nameof(Create), user.Id, user);
        }
    }
}
