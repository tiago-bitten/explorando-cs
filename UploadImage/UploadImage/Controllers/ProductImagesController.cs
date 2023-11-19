using Microsoft.AspNetCore.Mvc;
using UploadImage.Services;

namespace UploadImage.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductImagesController : ControllerBase
    {
        private readonly ProductImagesService _productImagesService;

        public ProductImagesController(ProductImagesService productImagesService)
        {
            _productImagesService = productImagesService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file,
                                                [FromQuery] string productId)
        {
            var productImage = await _productImagesService.Upload(file, productId);
            return CreatedAtAction(nameof(Upload), productImage.Id, productImage);
        }

        [HttpGet("recover")]
        public async Task<IActionResult> Recover([FromQuery] string imageKey)
        {
            var image = await _productImagesService.Recover(imageKey);
            return File(image, "image/jpeg");   
        }
    }
}
