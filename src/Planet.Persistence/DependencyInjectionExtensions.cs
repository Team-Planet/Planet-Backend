using Microsoft.Extensions.DependencyInjection;
using Planet.Application.Services.Repositories;
using Planet.Persistence.Repositories;

namespace Planet.Persistence
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
