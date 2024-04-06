using MediatR;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using Planet.Domain.Users;

namespace Planet.Application.Features.Users.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, ICryptographyService cryptographyService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _cryptographyService = cryptographyService;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Girilen şifreler eşleşmiyor!");
            }

            var firstName = FirstName.Create(request.FirstName);
            var lastName = LastName.Create(request.LastName);
            var email = Email.Create(request.Email);
            var userId = Guid.NewGuid();
            var createdDate = DateTime.Now;

            (string passwordHash, string salt) = _cryptographyService.HashPassword(request.Password);

            var user = User.Create(userId, email, passwordHash, salt, firstName, lastName, createdDate);

            await _userRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateUserResponse(user.Id, user.Email.Value, user.CreatedDate);

        }
    }
}
