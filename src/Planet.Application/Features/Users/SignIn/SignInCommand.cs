using MediatR;

namespace Planet.Application.Features.Users.SignIn
{
    public record SignInCommand(string Email, string Password) : IRequest<SignInResponse>;
}
