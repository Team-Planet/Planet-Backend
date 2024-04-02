using IdentityModel;
using MediatR;
using Planet.Application.Features.Users.SignIn;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;
using System.Security.Claims;

namespace Planet.Application.Features.Users.SignInRefresh
{
    internal class SignInRefreshCommandHandler : IRequestHandler<SignInRefreshCommand, SignInRefreshResponse>
    {
        private readonly IAuthenticationTokenService _authenticationTokenService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SignInRefreshCommandHandler(IAuthenticationTokenService authenticationTokenService, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _authenticationTokenService = authenticationTokenService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SignInRefreshResponse> Handle(SignInRefreshCommand request, CancellationToken cancellationToken)
        {
            var X = _authenticationTokenService.GetClaimsFromToken(request.AccessToken);
            var userId = _authenticationTokenService.GetClaimsFromToken(request.AccessToken).ToList().First(a => a.Type == JwtClaimTypes.Subject).Value;
            var user = await _userRepository.FindAsync(Guid.Parse(userId)); 
            DateTime userRefreshTokenExpireDate = DateTime.Parse(user.TokenExpireDate.ToString());
            DateTime now = DateTime.Now;
            var result = DateTime.Compare(userRefreshTokenExpireDate, now);
            if(result == -1 || result == 0)
            {
                var tokenModel = _authenticationTokenService.GenerateToken(GetClaims(user));
                user.SignIn(tokenModel.RefreshToken, tokenModel.RefreshTokenExpireDate);

                await _unitOfWork.SaveChangesAsync();

                return new SignInRefreshResponse(tokenModel);
            }
            throw new NotImplementedException();
        }
        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                new Claim(JwtClaimTypes.Name, $"{user.FirstName.Value} {user.LastName.Value}"),
                new Claim(JwtClaimTypes.Email, user.Email.Value),
            };

            return claims;
        }
    }
}
