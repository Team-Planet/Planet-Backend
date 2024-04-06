using MediatR;

namespace Planet.Application.Features.Users.Commands.SignInRefresh
{
    public record SignInRefreshCommand(string AccessToken, string RefreshToken) : IRequest<SignInRefreshResponse>;
}
