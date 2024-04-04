using Microsoft.EntityFrameworkCore;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Users;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Repositories
{
    public sealed class BoardRepository : IBoardRepository
    {
        private readonly PlanetContext _context;

        public BoardRepository(PlanetContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
        }
        public Task<Board> FindAsync(Guid id)
        {
            return _context.Boards.Include(b => b.Lists)
                .Include(b => b.Labels)
                .SingleOrDefaultAsync(b => b.Id == id);
        }
    }
}
