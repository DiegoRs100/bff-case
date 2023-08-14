using System.Text.Json;
using MarketPlace.BFF.Api.Common;

namespace MarketPlace.BFF.Api.HttpClients.MarketPlaceApi
{
    public class MarketPlaceApiResponseFactory : IMarketPlaceApiResponseFactory
    {
        public async Task<CustomResponse<TResponse>> CreateCustomResponse<TResponse>(HttpResponseMessage response)
        {
            var customResponse = new CustomResponse<TResponse>(response);

            var responseString = await response.Content.ReadAsStringAsync();

            var apiCoreResponse = JsonSerializer.Deserialize<MarketPlaceApiResponse<TResponse>>(responseString, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            })!;

            if (apiCoreResponse == null)
                return customResponse;

            if (response.IsSuccessStatusCode)
            {
                customResponse.SetData(apiCoreResponse.Data);
            }
            else
            {
                customResponse.SetErrors(apiCoreResponse.InvalidFields, apiCoreResponse.Notifications);
            }

            return customResponse;
        }
    }
}