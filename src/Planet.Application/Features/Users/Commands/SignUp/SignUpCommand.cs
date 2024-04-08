using MediatR;

namespace Planet.Application.Features.Users.Commands.SignUp
{
    public record SignUpCommand(
        string Email,
        string Password,
        string PasswordConfirmation,
        string FirstName,
        string LastName) : IRequest<SignUpResponse>;
}
