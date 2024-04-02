using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Infrastructure.Services.Authentication;
using Planet.Infrastructure.Services.Cryptography;

namespace Planet.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICryptographyService, CryptographyManager>();
            services.AddSingleton<IAuthenticationTokenService, JwtTokenManager>();

            services.AddScoped<IUserService, UserManager>();

            return services;
        }
    }
}
