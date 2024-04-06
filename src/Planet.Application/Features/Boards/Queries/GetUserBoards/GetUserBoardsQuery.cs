using MediatR;

namespace Planet.Application.Features.Boards.Queries.GetUserBoards
{
    public record GetUserBoardsQuery() : IRequest<GetUserBoardsResponse>;
}
