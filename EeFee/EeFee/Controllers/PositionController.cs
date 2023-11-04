using EeFee.DTOs;
using EeFee.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EeFee.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePositionDTO dto)
        {
            var positionDTO = await _positionService.CreateAsync(dto);
            return CreatedAtAction(nameof(Create), positionDTO.Id, positionDTO);
        }
    }
}
