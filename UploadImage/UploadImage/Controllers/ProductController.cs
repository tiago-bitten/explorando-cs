using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadImage.Dtos;
using UploadImage.Services;

namespace UploadImage.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateProductDto dto)
        {
            ReadProductDto product = await _productService.Create(dto);
            return CreatedAtAction(nameof(Create), product.Id, product);
        }
    }
}
