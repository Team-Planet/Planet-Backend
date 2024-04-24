using Planet.Application.Common;
using Planet.Application.Features.Cards.Commands.EditDescription;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.EditCardDescription
{
    internal class EditCardDescriptionCommandHandler : RequestHandlerBase<EditCardDescriptionCommand, EditCardDescriptionResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public EditCardDescriptionCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
        }
        public override async Task<EditCardDescriptionResponse> Handle(EditCardDescriptionCommand request, CancellationToken cancellationToken)
        {
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, request.CardId))
            {
                return Response.Failure<EditCardDescriptionResponse>(OperationMessages.DoNotHavePermissionForEditCardDescription);
            }

            var cardId = request.CardId;
            var card = await _cardRepository.FindAsync(cardId);
            var description = CardDescription.Create(request.Description);
            card.ChangeCardDescription(description);

            await _unitOfWork.SaveChangesAsync();

            return Response.SuccessWithBody<EditCardDescriptionResponse>(new
            {
                CardId = cardId,
                Description = description.Value
            }, OperationMessages.EditedCardDescriptionSuccessfully);
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