using MediatR;

namespace Planet.Application.Features.Boards.AddList
{
    public record AddListCommand(
        Guid boardId,
        string title,
        int order
        ) :IRequest<AddListResponse>;
}
