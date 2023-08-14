using MarketPlace.BFF.Api.Common;
using MarketPlace.BFF.Api.Facades.Interfaces;
using MarketPlace.BFF.Api.HttpClients.MarketPlaceApi;
using MarketPlace.BFF.Api.ViewModels;

namespace MarketPlace.BFF.Api.Facades
{
    public class StoreFacade : IStoreFacade
    {
        private readonly IMarketPlaceApiResponseFactory _apiCoreResponseFactory;
        private readonly HttpClient _httpClient;

        public StoreFacade(IMarketPlaceApiResponseFactory apiCoreResponseFactory,
                           HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiCoreResponseFactory = apiCoreResponseFactory;
        }

        public async Task<CustomResponse<IEnumerable<StoreViewModel>>> GetAll()
        {
            var httpResponse = await _httpClient.GetAsync($"all");
            return await _apiCoreResponseFactory.CreateCustomResponse<IEnumerable<StoreViewModel>>(httpResponse);
        }
    }
}