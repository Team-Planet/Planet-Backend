using MediatR;

namespace Planet.Application.Features.Users.Commands.ChangePassword
{
    public record ChangePasswordCommand(string OldPassword, string NewPassword) : IRequest<ChangePasswordResponse>;

}
