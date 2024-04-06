namespace Planet.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserResponse(Guid UserId, string Email, DateTime CreatedDate);
}
