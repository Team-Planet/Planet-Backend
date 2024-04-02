using MediatR;

namespace Planet.Application.Features.Users.ChangePassword
{
    public record ChangePasswordCommand(string OldPassword, string NewPassword) : IRequest<ChangePasswordResponse>;

}
