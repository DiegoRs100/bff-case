using MarketPlace.BFF.Api.Common;
using MarketPlace.BFF.Api.HttpClients.MarketPlaceApi;
using MarketPlace.BFF.Api.ViewModels;
using System.Text;
using System.Text.Json;

namespace MarketPlace.BFF.Api.Facades.Interfaces
{
    public class ProductFacade : IProductFacade
    {
        private readonly IMarketPlaceApiResponseFactory _apiCoreResponseFactory;
        private readonly HttpClient _httpClient;

        public ProductFacade(IMarketPlaceApiResponseFactory apiCoreResponseFactory,
                             HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiCoreResponseFactory = apiCoreResponseFactory;
        }

        public async Task<CustomResponse<ProductViewModel>> GetById(Guid productId)
        {
            var httpResponse = await _httpClient.GetAsync(productId.ToString());
            return await _apiCoreResponseFactory.CreateCustomResponse<ProductViewModel>(httpResponse);
        }

        public async Task<CustomResponse<ProductViewModel>> CreateProduct(ProductViewModel product)
        {
            var content = new StringContent(JsonSerializer.Serialize(product), Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync(string.Empty, content);
            return await _apiCoreResponseFactory.CreateCustomResponse<ProductViewModel>(httpResponse);
        }
    }
}