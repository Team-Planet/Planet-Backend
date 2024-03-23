using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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

            var boards = await context.Boards.Include(b => b.Lists).ToListAsync();
            var lists = boards.SelectMany(b => b.Lists);
            var members = boards.SelectMany(b => b.Members);
            var listGroups = lists.GroupBy(l => l.BoardId).ToList();
            var memberGroups = members.GroupBy(m => m.BoardId).ToList();

            if (!context.Cards.Any())
            {
                await context.Cards.AddRangeAsync(CardStore.GetCards(memberGroups, listGroups));
            }
            await context.SaveChangesAsync();
        }
    }
}
