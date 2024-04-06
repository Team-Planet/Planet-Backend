using IdentityModel;
using MediatR;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;
using System.Security.Claims;

namespace Planet.Application.Features.Users.Commands.SignInRefresh
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
            var userId = _authenticationTokenService.GetClaimsFromToken(request.AccessToken).First(a => a.Type == JwtClaimTypes.Subject).Value;
            var user = await _userRepository.FindAsync(Guid.Parse(userId));

            if (!user.TokenExpireDate.HasValue || user.TokenExpireDate < DateTime.Now)
            {
                throw new Exception("RefreshToken süresi dolmuş.");
            }

            if (request.RefreshToken != user.RefreshToken)
            {
                throw new Exception("RefreshToken geçerli değil.");
            }

            var tokenModel = _authenticationTokenService.GenerateToken(GetClaims(user));
            user.SignIn(tokenModel.RefreshToken, tokenModel.RefreshTokenExpireDate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SignInRefreshResponse(tokenModel);
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
