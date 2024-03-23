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
            if (!context.Users.Any())
            {
                await context.Users.AddRangeAsync(UserStore.GetUsers());
            }
            if (!context.Boards.Any())
            {
                await context.Boards.AddRangeAsync(BoardStore.GetBoards());
            }
            //if (!context.Cards.Any())
            //{
            //    await context.Cards.AddRangeAsync(CardStore.GetCards());
            //}
            await context.SaveChangesAsync();
        }
    }
}
