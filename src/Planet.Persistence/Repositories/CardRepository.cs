using Microsoft.EntityFrameworkCore;
using Planet.Application.Services.Repositories;
using Planet.Domain.Cards;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Repositories
{
    public sealed class CardRepository : ICardRepository
    {
        private readonly PlanetContext _context;

        public CardRepository(PlanetContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Card entity)
        {
            await _context.Cards.AddAsync(entity);
        }

        public Task<Card> FindAsync(Guid id)
        {
            return _context.Cards.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
