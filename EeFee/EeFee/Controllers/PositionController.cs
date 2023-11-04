using Microsoft.AspNetCore.Mvc;

namespace EeFee.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
    }
}
