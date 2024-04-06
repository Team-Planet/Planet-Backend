using Planet.Application.Models.Boards;
using Planet.Domain.Boards;

namespace Planet.Application.Services.Repositories
{
    public interface IBoardRepository : IBoardDomainRepository
    {
        Task<List<UserBoardModel>> GetUserBoardsAsync(Guid userId);
    }
}
