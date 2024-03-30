using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Infrastructure.Services.Cryptography;
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
        private readonly IUserRepository _userRepository;

        public UsersController(ICryptographyService cryptographyService, IAuthenticationTokenService authenticationTokenService, IUserRepository userRepository)
        {
            _cryptographyService = cryptographyService;
            _authenticationTokenService = authenticationTokenService;
            _userRepository = userRepository;
        }

        //[HttpGet("[action]")]
        //[AllowAnonymous]
        //public IActionResult /*SignIn*/()
        //{
        //    // Veritabanından bilgiler çekiliyor
        //    var claims = new List<Claim>()
        //    {
        //        new Claim(JwtClaimTypes.Subject, Guid.NewGuid().ToString()),
        //        new Claim(JwtClaimTypes.Name, "Emre Özgenç"),
        //        new Claim(JwtClaimTypes.PhoneNumber, "05312165238"),
        //        new Claim(JwtClaimTypes.Email, "emreozgenc@hotmail.com.tr")
        //    };

        //    return Ok(_authenticationTokenService.GetToken(claims));
        //}
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(string email,string password)
        {
            var user = await _userRepository.FindByEmailAsync(email);
            bool isVerified = _cryptographyService.VerifyPassword(password, user.Salt, user.Password); //Password: burkay123
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtClaimTypes.Email, user.Email.Value),
            };
            var token_model = _authenticationTokenService.GetToken(claims);
            user.UpdateRefreshToken(token_model.RefreshToken);
            user.UpdateTokenExpireDate(token_model.RefreshTokenExpireDate);
            await _userRepository.UpdateAsync(user);
            return Ok(token_model);
        }
        
    }
}
