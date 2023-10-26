using CrudApi.DTOs;
using CrudApi.Models;
using CrudApi.Repositories;
using CrudApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            return Ok(await _userRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            return Ok(await _userRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] User user)
        {
            return Created("", await _userRepository.CreateAsync(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, [FromBody] UserDto dto)
        {
            return Ok(await _userRepository.UpdateAsync(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            return Ok(await _userRepository.DeleteAsync(id));
        }
    }
}
