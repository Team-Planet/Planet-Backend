using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;
using Planet.Persistence.Contexts;
using Planet.Persistence.Seeding;

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
        public async Task UpdateAsync(User user)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            _context.SaveChanges();
            
        }
        public Task<User> FindAsync(Guid id)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Email.Value == email);
        }
    }
}