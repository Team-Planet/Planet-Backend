using MediatR;

namespace Planet.Application.Features.Users.Commands.SignIn
{
    public record SignInCommand(string Email, string Password) : IRequest<SignInResponse>;
}
