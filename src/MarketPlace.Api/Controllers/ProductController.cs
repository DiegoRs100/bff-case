using MarketPlace.Api.Common;
using MarketPlace.Api.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketPlace.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        { }

        [HttpPost]
        [SwaggerOperation("Crete new product.")]
        public IActionResult CreateProduct(ProductViewModel product)
        {
            var result = new ApiResult<ProductViewModel>();

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                result.InvalidFields.Add("Invalid name.");
                return BadRequest(result);
            }

            result.Data = product;

            return Created($"{HttpContext.Request.GetDisplayUrl()}/{product.Id}", result);
        }

        [HttpGet("{productId:Guid}")]
        [SwaggerOperation(
            Summary = "Get product by ID.", 
            Description = "Valid ID = 7205b2f7-ff9f-495a-924c-9fe2b687fd5c")]
        public IActionResult Get(Guid productId)
        {
            var result = new ApiResult<ProductViewModel>();

            if (productId != new Guid("7205b2f7-ff9f-495a-924c-9fe2b687fd5c"))
            {
                result.Notifications.Add("The specified product does not exist.");
                return NotFound(result);
            }

            result.Data = new ProductViewModel(Guid.NewGuid(), "Pineapple soda");

            return Ok(result);
        }
    }
}