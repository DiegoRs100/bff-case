using MarketPlace.BFF.Api.Services;
using MarketPlace.BFF.Api.Services.Interfaces;

namespace MarketPlace.BFF.Api.IoC
{
    public static partial class IoC
    {
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}