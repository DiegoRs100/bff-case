using MarketPlace.BFF.Api.Facades;
using MarketPlace.BFF.Api.Facades.Interfaces;

namespace MarketPlace.BFF.Api.IoC
{
    public static partial class IoC
    {
        private static IServiceCollection AddFacades(this IServiceCollection services)
        {
            services.AddScoped<IStoreFacade, StoreFacade>();
            services.AddScoped<IProductFacade, ProductFacade>();

            return services;
        }
    }
}