using MarketPlace.BFF.Api.Common;
using MarketPlace.BFF.Api.Facades;
using MarketPlace.BFF.Api.Facades.Interfaces;
using MarketPlace.BFF.Api.HttpClients.MarketPlaceApi;

namespace MarketPlace.BFF.Api.IoC
{
    public static partial class IoC
    {
        private static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpHandlers();

            var apiClients = configuration.GetSection("ApiClientSettings")
                .Get<IEnumerable<ApiClientSettings>>()!;

            var apiCoreSettings = apiClients.GetClient("CoreApi");

            services.AddHttpClient<IStoreFacade, StoreFacade>(options =>
            {
                options.BaseAddress = new Uri($"{apiCoreSettings.BaseUrl}/stores/");
                options.Timeout = TimeSpan.FromSeconds(5);
            }).AddHttpMessageHandler<MarketPlaceApiAuthenticationHttpHandler>()
              .AddHttpMessageHandler<MarketPlaceApiLogHttpHandler>();

            services.AddHttpClient<IProductFacade, ProductFacade>(options =>
            {
                options.BaseAddress = new Uri($"{apiCoreSettings.BaseUrl}/products/");
            }).AddHttpMessageHandler<MarketPlaceApiAuthenticationHttpHandler>()
              .AddHttpMessageHandler<MarketPlaceApiLogHttpHandler>();

            return services;
        }

        private static IServiceCollection AddHttpHandlers(this IServiceCollection services)
        {
            services.AddScoped<MarketPlaceApiLogHttpHandler>();
            services.AddScoped<MarketPlaceApiAuthenticationHttpHandler>();

            return services;
        }

        private static ApiClientSettings GetClient(this IEnumerable<ApiClientSettings> apiClients, string clientName)
        {
            return apiClients.First(c => c.ApiClient == clientName);
        }
    }
}