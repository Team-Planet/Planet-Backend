using IdentityModel;
using MediatR;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;
using System.Security.Claims;

namespace Planet.Application.Features.Users.SignIn
{
    internal class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResponse>
    {
        private readonly ICryptographyService _cryptographyService;
        private readonly IAuthenticationTokenService _authenticationTokenService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SignInCommandHandler(ICryptographyService cryptographyService, IAuthenticationTokenService authenticationTokenService, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _cryptographyService = cryptographyService;
            _authenticationTokenService = authenticationTokenService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);
            bool isVerified = _cryptographyService.VerifyPassword(request.Password, user.Salt, user.Password);

            if(!isVerified)
            {
                throw new Exception("Yanlış kullanıcı adı veya şifre!");
            }

            var tokenModel = _authenticationTokenService.GetToken(GetClaims(user));
            user.SignIn(tokenModel.RefreshToken, tokenModel.RefreshTokenExpireDate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SignInResponse(tokenModel);
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
