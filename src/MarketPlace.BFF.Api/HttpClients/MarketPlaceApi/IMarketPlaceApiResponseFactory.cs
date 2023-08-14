using MarketPlace.BFF.Api.Common;

namespace MarketPlace.BFF.Api.HttpClients.MarketPlaceApi
{
    public interface IMarketPlaceApiResponseFactory
    {
        Task<CustomResponse<TResponse>> CreateCustomResponse<TResponse>(HttpResponseMessage response);
    }
}