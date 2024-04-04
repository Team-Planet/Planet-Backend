using MediatR;
using Planet.Domain.Boards;

namespace Planet.Application.Features.Boards.RemoveList
{
    public record RemoveListCommand(
        Guid BoardId,
        Guid BoardListId
        ) : IRequest<RemoveListResponse>;
}
