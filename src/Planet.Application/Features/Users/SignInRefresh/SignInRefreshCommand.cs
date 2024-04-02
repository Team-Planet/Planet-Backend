using MediatR;
using Planet.Application.Models.Authentication;

namespace Planet.Application.Features.Users.SignInRefresh
{
    public record SignInRefreshCommand(string AccessToken, string refreshToken): IRequest<SignInRefreshResponse>;
}
