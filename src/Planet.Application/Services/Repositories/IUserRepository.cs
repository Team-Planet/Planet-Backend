using Planet.Application.Models.Users;
using Planet.Domain.Users;

namespace Planet.Application.Services.Repositories
{
    public interface IUserRepository : IUserDomainRepository
    {
        Task<Dictionary<string, int>> GetUserStatistics(Guid userId);
    }
}
