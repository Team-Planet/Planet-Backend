using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using Planet.Persistence.Contexts;
using Planet.Persistence.Repositories;

namespace Planet.Persistence
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlanetContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();

            return services;
        }
    }
}
