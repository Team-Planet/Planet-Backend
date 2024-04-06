using MediatR;

namespace Planet.Application.Features.Boards.Commands.InviteMember
{
    public record InviteMemberCommand(Guid BoardId) : IRequest<InviteMemberResponse>;
}
