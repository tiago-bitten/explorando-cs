using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EeFee.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
    }
}
