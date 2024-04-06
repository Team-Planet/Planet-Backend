using IdentityModel;
using MediatR;
using Microsoft.Extensions.Configuration;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.SharedKernel;
using System.Text;

namespace Planet.Application.Features.Boards.Commands.AcceptInvitation
{
    public class AcceptInvitationCommandHandler : IRequestHandler<AcceptInvitationCommand, AcceptInvitationResponse>
    {
        private readonly ICryptographyService _cryptographyService;
        private readonly IBoardRepository _boardRepository;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public AcceptInvitationCommandHandler(ICryptographyService cryptographyService, IBoardRepository boardRepository, IConfiguration configuration, IUserService userService, IUnitOfWork unitOfWork)
        {
            _cryptographyService = cryptographyService;
            _boardRepository = boardRepository;
            _configuration = configuration;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<AcceptInvitationResponse> Handle(AcceptInvitationCommand request, CancellationToken cancellationToken)
        {
            byte[] cipher = Base64Url.Decode(request.InvitationKey);
            byte[] decrypted = _cryptographyService.Decrypt(_configuration["Invitation:Key"], cipher);
            string invitationKey = Encoding.UTF8.GetString(decrypted);

            string[] parameters = invitationKey.Split('~');
            Guid boardId = Guid.Parse(parameters[0]);
            DateTime expireDate = DateTime.Parse(parameters[1]);
            Guid userId = _userService.GetUserId();

            if (DateTime.Now > expireDate)
            {
                throw new Exception("Davet bağlantısının süresi dolmuş!");
            }

            var board = await _boardRepository.FindAsync(boardId);

            if (board is null)
            {
                throw new Exception("Board bulunamadı!");
            }

            var boardMember = BoardMember.Create(userId, board.Id, BoardPermissions.View, DateTime.Now, true);

            board.AddMember(boardMember);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new AcceptInvitationResponse();
        }
    }
}
