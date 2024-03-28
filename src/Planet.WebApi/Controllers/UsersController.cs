using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using System.Security.Claims;

namespace Planet.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly ICryptographyService _cryptographyService;
        private readonly IAuthenticationTokenService _authenticationTokenService;

        public UsersController(ICryptographyService cryptographyService, IAuthenticationTokenService authenticationTokenService)
        {
            _cryptographyService = cryptographyService;
            _authenticationTokenService = authenticationTokenService;
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            // Veritabanından bilgiler çekiliyor
            var claims = new List<Claim>()
            {
                new Claim(JwtClaimTypes.Subject, Guid.NewGuid().ToString()),
                new Claim(JwtClaimTypes.Name, "Emre Özgenç"),
                new Claim(JwtClaimTypes.PhoneNumber, "05312165238"),
                new Claim(JwtClaimTypes.Email, "emreozgenc@hotmail.com.tr")
            };

            return Ok(_authenticationTokenService.GetToken(claims));
        }


    }
}
