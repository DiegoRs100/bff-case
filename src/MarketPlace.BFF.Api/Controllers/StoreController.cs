using MarketPlace.BFF.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MarketPlace.BFF.Api.Controllers
{
    [ApiController]
    [Route("store")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet("all")]
        [SwaggerOperation("Get all stores.")]
        public async Task<IActionResult> Get()
        {
            var result = await _storeService.GetAll();
            return Ok(result);
        }
    }
}