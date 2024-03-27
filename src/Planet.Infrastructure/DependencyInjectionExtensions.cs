using Microsoft.Extensions.DependencyInjection;
using Planet.Application.Services.Cryptography;
using Planet.Infrastructure.Services.Cryptography;

namespace Planet.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ICryptographyService, CryptographyManager>();

            return services;
        }
    }
}
