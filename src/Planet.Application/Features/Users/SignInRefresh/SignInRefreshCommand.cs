using MediatR;

namespace Planet.Application.Features.Users.SignInRefresh
{
    public record SignInRefreshCommand(string AccessToken, string RefreshToken): IRequest<SignInRefreshResponse>;
}
