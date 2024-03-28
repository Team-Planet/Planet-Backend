using Planet.Application.Models.Authentication;
using System.Security.Claims;

namespace Planet.Application.Services.Authentication
{
    public interface IAuthenticationTokenService
    {
        TokenModel GetToken(IEnumerable<Claim> claims);
    }
}
