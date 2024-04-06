using MediatR;

namespace Planet.Application.Features.Boards.Commands.AddList
{
    public record AddListCommand(
        Guid BoardId,
        string Title,
        int Order
        ) : IRequest<AddListResponse>;
}
