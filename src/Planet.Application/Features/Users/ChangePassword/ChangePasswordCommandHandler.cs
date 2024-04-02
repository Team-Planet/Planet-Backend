using MediatR;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Users.ChangePassword
{
    internal class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;
        private readonly IUnitOfWork _unitOfWork;

        public ChangePasswordCommandHandler(IUserRepository userRepository, ICryptographyService cryptographyService , IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _cryptographyService = cryptographyService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            if (!_cryptographyService.VerifyPassword(request.OldPassword, user.Salt, user.Password))
            {
                throw new Exception("Eski şifre yanlış.");
            }

            
            (string newPasswordHash, string newSalt) = _cryptographyService.HashPassword(request.NewPassword);
            user.UpdatePassword(newPasswordHash, newSalt);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ChangePasswordResponse(user.Id);
        }
    }
}
