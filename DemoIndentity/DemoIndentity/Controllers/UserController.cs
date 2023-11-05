using DemoIndentity.Data.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoIndentity.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
