using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controller
{
    [ApiController]
    [Route("/api/v1/home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}
