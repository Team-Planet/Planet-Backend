using Planet.Application.Common;
using Planet.Application.Features.Boards.Queries.GetUserBoards;
using Planet.Application.Models.Boards;
using Planet.Domain.Boards;

namespace Planet.Application.Services.Repositories
{
    public interface IBoardRepository : IBoardDomainRepository
    {
        Task<Pagination<UserBoardModel>> GetUserBoardsAsync(GetUserBoardsQuery query, Guid userId);
        Task<bool> HasPermission(BoardPermissions permission, Guid boardId, Guid userId);
        Task<BoardModel> GetBoardAsync(Guid boardId);
        Task<bool> HasBoardListAnyCard(Guid listId);
    }
}
