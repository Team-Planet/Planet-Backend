using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Seeding
{
    public static class SeedingExtensions
    {
        public static async Task SeedAsync(this IApplicationBuilder builder, IConfiguration configuration)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<PlanetContext>();
            BoardStore.GetBoards();
            if (!context.Users.Any())
            {
                await context.Users.AddRangeAsync(UserStore.GetUsers());
            }
            await context.SaveChangesAsync();
        }
    }
}
