using Microsoft.EntityFrameworkCore;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly PlanetContext _context;

        public UserRepository(PlanetContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public Task<User> FindAsync(Guid id)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
