using Planet.Domain.SharedKernel;
using Microsoft.AspNetCore.Builder;
namespace Planet.Domain.Users
{
    public interface IUserDomainRepository : IDomainRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
        Task UpdateAsync(User user);
    }
}
