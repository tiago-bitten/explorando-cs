using EeFee.DTOs;
using EeFee.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EeFee.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            return Ok(await _userService.FindAllAsync(skip, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            return Ok(await _userService.FindByIdAsync(id));
        }

        [HttpGet("position")]
        public async Task<IActionResult> FindByPosition([FromQuery] int positionId)
        {
            return Ok(await _userService.FindByPosition(positionId));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO dto)
        {
            var userDTO = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), userDTO.Id, userDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
