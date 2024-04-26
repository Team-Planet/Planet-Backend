using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.AssignUser
{
    internal class AssignUserCommandHandler : RequestHandlerBase<AssignUserCommand, AssignUserResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public AssignUserCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
        }

        public override async Task<AssignUserResponse> Handle(AssignUserCommand request, CancellationToken cancellationToken)
        {
            if (!await HasPermissionAsync(BoardPermissions.AssignCard, request.CardId))
            {
                return Response.Failure<AssignUserResponse>(OperationMessages.DoNotHavePermissionForAssigningUserToCard);
            }

            /*
             *  Atanan kullanıcının board'a üyeliği var mı?
             */

            var cardId = request.CardId;
            var card = await _cardRepository.FindAsync(cardId);

            card.AssignUser(request.UserId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.Success<AssignUserResponse>();
        }

        private async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid cardId)
        {
            var userId = _userService.GetUserId();
            return await _boardRepository.HasPermissionAsync(permission, cardId, userId);
        }
    }
}
