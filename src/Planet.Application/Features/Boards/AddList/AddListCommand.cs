using MediatR;

namespace Planet.Application.Features.Boards.AddList
{
    public record AddListCommand(
        Guid BoardId,
        string Title,
        int Order
        ) :IRequest<AddListResponse>;
}
