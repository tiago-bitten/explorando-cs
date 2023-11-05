using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoIndentity.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AcessController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "MinimumAge")]
        public IActionResult Get()
        {
            return Ok("Acess granted");
        }
    }
}
