using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.AddCardCheckList
{
    public class AddCardCheckListCommandHandler : RequestHandlerBase<AddCardCheckListCommand, AddCardCheckListResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public AddCardCheckListCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
        }
        public override async Task<AddCardCheckListResponse> Handle(AddCardCheckListCommand request, CancellationToken cancellationToken)
        {
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, request.CardId))
            {
                return Response.Failure<AddCardCheckListResponse>(OperationMessages.DoNotHavePermissionForAddCardCheckList);
            }
            var id = Guid.NewGuid();
            var cardId = request.CardId;
            var title = CardTitle.Create(request.Title);
            var card = await _cardRepository.FindAsync(cardId);

            var cardCheckList = CardCheckList.Create(id, cardId, title);
            card.AddCheckList(cardCheckList);
            await _unitOfWork.SaveChangesAsync(cancellationToken);


            return Response.SuccessWithBody<AddCardCheckListResponse>(new
            {
                CardId = cardId,
                Title = title.Value,
                CheckListId = cardCheckList.Id
            }, OperationMessages.AddedCheckListToCardSuccessfully);
        }

        private Task<bool> HasPermissionAsync(BoardPermissions permission, Guid cardId)
        {
            var userId = _userService.GetUserId();
            return _boardRepository.HasPermissionAsync(permission, cardId, userId);
        }

    }

}
