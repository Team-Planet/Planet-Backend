using MediatR;

namespace Planet.Application.Features.Boards.Commands.AcceptInvitation
{
    public record AcceptInvitationCommand(string InvitationKey) : IRequest<AcceptInvitationResponse>;
}
