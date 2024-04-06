using Planet.Application.Models.Boards;

namespace Planet.Application.Features.Boards.Queries.GetUserBoards
{
    public record GetUserBoardsResponse(List<UserBoardModel> Boards);
}
