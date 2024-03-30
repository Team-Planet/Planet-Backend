using MediatR;

namespace Planet.Application.Features.Users.CreateUser
{
    public record CreateUserCommand(
        string Email,
        string Password,
        string PasswordConfirmation,
        string FirstName,
        string LastName) : IRequest<CreateUserResponse>;
}
