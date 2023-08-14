using MarketPlace.BFF.Api.HttpClients.MarketPlaceApi;

namespace MarketPlace.BFF.Api.IoC
{
    public static partial class IoC
    {
        private static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddScoped<IMarketPlaceApiResponseFactory, MarketPlaceApiResponseFactory>();
            return services;
        }
    }
}