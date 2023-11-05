using AutoMapper;
using DemoIndentity.Data.Dtos;
using DemoIndentity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoIndentity.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserController(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            user.DateOfBirth = user.DateOfBirth.ToUniversalTime();

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
            
            if (!result.Succeeded)
            {
                throw new ApplicationException(result.Errors.First().Description);
            }

            return Ok();
        }
    }
}
