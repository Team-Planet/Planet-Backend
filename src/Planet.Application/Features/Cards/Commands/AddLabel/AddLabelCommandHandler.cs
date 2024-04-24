using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.AddLabel
{
    internal class AddLabelCommandHandler : RequestHandlerBase<AddLabelCommand, AddLabelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;
        private readonly ICardRepository _cardRepository;

        public AddLabelCommandHandler(IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository, ICardRepository cardRepository)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
            _cardRepository = cardRepository;
        }
        public override async Task<AddLabelResponse> Handle(AddLabelCommand request, CancellationToken cancellationToken)
        {
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, request.CardId))
            {
                return Response.Failure<AddLabelResponse>(OperationMessages.DoNotHavePermissionForEditCardDescription);
            }

            var cardId = request.CardId;
            var boardLabelId = request.BoardLabelId;
            var card = await _cardRepository.FindAsync(cardId);

            var cardLabel = CardLabel.Create(cardId, boardLabelId);
            card.AddLabel(cardLabel);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<AddLabelResponse>(new
            {
                CardId = cardId,
                BoardLabelId = boardLabelId
            }, OperationMessages.AddedLabelToCardSuccessfully);
        }
        private async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid cardId)
        {
            var userId = _userService.GetUserId();
            var list = await _cardRepository.FindAsync(cardId);
            var listId = list.ListId;
            return await _boardRepository.HasPermissionForListAsync(permission, listId, userId);
        }
    }
}
