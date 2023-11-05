using AutoMapper;
using DemoIndentity.Data.Dtos;
using DemoIndentity.Models;
using DemoIndentity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoIndentity.Controllers
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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            User user = await _userService.Create(dto);

            return CreatedAtAction(nameof(Create), new {id = user.Id}, user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            await _userService.Login(dto);

            return Ok("Logado com sucesso");
        }
    }
}
