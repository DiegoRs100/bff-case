namespace MarketPlace.BFF.Api.IoC
{
    public static partial class IoC
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFactories();
            services.AddServices();
            services.AddFacades();
            services.AddHttpClients(configuration);

            return services;
        }
    }
}