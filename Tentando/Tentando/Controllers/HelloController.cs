using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tentando.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet(Name = "GetHello")]
        public ActionResult<string> Get()
        {
            return Ok("Hello World!");
        }
    }
}
