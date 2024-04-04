using MediatR;
using Planet.Domain.Boards;

namespace Planet.Application.Features.Boards.RemoveList
{
    public record RemoveListCommand(
        Guid boardId,
        Guid boardListId
        ) : IRequest<RemoveListResponse>;
}
