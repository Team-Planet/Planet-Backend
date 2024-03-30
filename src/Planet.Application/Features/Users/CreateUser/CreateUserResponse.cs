namespace Planet.Application.Features.Users.CreateUser
{
    public record CreateUserResponse(Guid UserId, string Email, DateTime CreatedDate);
}
