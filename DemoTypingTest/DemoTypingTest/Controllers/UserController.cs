using DemoTypingTest.Data.Dtos;
using DemoTypingTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoTypingTest.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationUserService _userService;

        public UserController(ApplicationUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("profile/image")]
        public async Task<IActionResult> UploadProfileImage([FromForm] IFormFile file,
            [FromQuery] string userId)
        {
            return Ok(await _userService.UploadProfileImage(file, userId));
        }

        [HttpGet("profile/image")]
        public async Task<IActionResult> RecoverProfileImage([FromQuery] string userId)
        {
            return NoContent();
        }

        [HttpDelete("profile/image")]
        public async Task<IActionResult> DeleteProfileImage([FromQuery] string userId)
        {
            return NoContent();
        }
    }
}
