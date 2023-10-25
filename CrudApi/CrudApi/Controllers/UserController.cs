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
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _userRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            return Created("", await _userRepository.CreateAsync(user));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update(int id, [FromBody] User user)
        {
            return Ok(await _userRepository.UpdateAsync(id, user));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            return Ok(await _userRepository.DeleteAsync(id));
        }
    }
}
