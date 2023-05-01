using Frankfurter.API.Client.Configuration;
using Frankfurter.API.Client.Infraestructure;
using Microsoft.Extensions.DependencyInjection;

namespace Frankfurter.API.Client.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFrankfurterApiClient(this IServiceCollection services)
        {
            services.AddTransient<IFrankfurterClientHttpClient, FrankfurterClientHttpClient>();

            services.AddTransient<IFrankfurterClient>(x =>
                new FrankfurterClient(x.GetRequiredService<IFrankfurterClientHttpClient>()));

            return services;
        }

        public static IServiceCollection AddFrankfurterApiClient(this IServiceCollection services, string baseUrl)
        {
            services.AddTransient<IFrankfurterClientHttpClient>(_ =>
                new FrankfurterClientHttpClient(baseUrl));

            services.AddTransient<IFrankfurterClient>(x =>
                new FrankfurterClient(x.GetRequiredService<IFrankfurterClientHttpClient>()));

            return services;
        }

        public static IServiceCollection AddFrankfurterApiClient(this IServiceCollection services, FrankfurterClientConfiguration configs)
        {
            services.AddTransient<IFrankfurterClientHttpClient>(_ =>
                new FrankfurterClientHttpClient(configs));

            services.AddTransient<IFrankfurterClient>(x =>
                new FrankfurterClient(x.GetRequiredService<IFrankfurterClientHttpClient>()));

            return services;
        }
    }
}
