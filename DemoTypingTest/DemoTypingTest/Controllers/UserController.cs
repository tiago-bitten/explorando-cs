using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoTypingTest.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var user = await _userService.Create(dto);
            return CreatedAtAction(nameof(Create), user.Id, user);
        }
    }
}
