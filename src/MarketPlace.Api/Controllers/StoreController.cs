using MarketPlace.Api.Common;
using MarketPlace.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketPlace.Api.Controllers
{
    [ApiController]
    [Route("stores")]
    public class StoreController : ControllerBase
    {
        public StoreController()
        { }

        [HttpGet("all")]
        [SwaggerOperation("Get all stores.")]
        public IActionResult Get()
        {
            var result = new List<StoreViewModel>()
            {
                new StoreViewModel(Guid.NewGuid(), "Store 01"),
                new StoreViewModel(Guid.NewGuid(), "Store 02")
            };

            return Ok(new ApiResult<IEnumerable<StoreViewModel>>(result));
        }

        [HttpGet("{productId:Guid}")]
        [SwaggerOperation(
            Summary = "Get store by ID.",
            Description = "Valid ID = e0d7a770-c7c4-43ee-b2d0-71539130b357")]
        public IActionResult Get(Guid productId)
        {
            var result = new ApiResult<StoreViewModel>();

            if (productId != new Guid("e0d7a770-c7c4-43ee-b2d0-71539130b357"))
            {
                result.Notifications.Add("The specified store does not exist.");
                return NotFound(result);
            }

            result.Data = new StoreViewModel(Guid.NewGuid(), "Center Store");

            return Ok(result);
        }
    }
}