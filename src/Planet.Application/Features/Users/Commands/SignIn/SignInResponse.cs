using Planet.Application.Models.Authentication;

namespace Planet.Application.Features.Users.Commands.SignIn
{
    public record SignInResponse(TokenModel TokenInfo);
}
