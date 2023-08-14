using MarketPlace.BFF.Api.Services.Interfaces;
using MarketPlace.BFF.Api.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketPlace.BFF.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [SwaggerOperation("Crete new product.")]
        public async Task<IActionResult> CreateProduct(ProductViewModel product)
        {
            var result = await _productService.CreateProduct(product);
            
            return result.IsSuccess
                ? Created($"{HttpContext.Request.GetDisplayUrl()}/{product.Id}", result.Data)
                : BadRequest(result.Notifications);
        }

        [HttpGet("{productId:Guid}")]
        [SwaggerOperation(
            Summary = "Get product by ID.",
            Description = "Valid ID = 7205b2f7-ff9f-495a-924c-9fe2b687fd5c")]
        public async Task<IActionResult> Get(Guid productId)
        {
            var result = await _productService.GetById(productId);

            return result.IsSuccess
                ? Ok(result.Data)
                : BadRequest(result.Notifications);
        }
    }
}