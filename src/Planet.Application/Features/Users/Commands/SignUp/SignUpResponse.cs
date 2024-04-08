namespace Planet.Application.Features.Users.Commands.SignUp
{
    public record SignUpResponse(Guid UserId, string Email, DateTime CreatedDate);
}
