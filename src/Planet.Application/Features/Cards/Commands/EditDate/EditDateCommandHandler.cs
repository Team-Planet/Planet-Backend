using MediatR.Wrappers;
using Planet.Application.Common;
using Planet.Application.Features.Cards.Commands.EditCardDescription;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Commands.EditDate
{
    internal class EditDateCommandHandler : RequestHandlerBase<EditDateCommand, EditDateResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBoardRepository _boardRepository;

        public EditDateCommandHandler(ICardRepository cardRepository, IUserService userService, IUnitOfWork unitOfWork, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
            _boardRepository = boardRepository;
        }
        public override async Task<EditDateResponse> Handle(EditDateCommand request, CancellationToken cancellationToken)
        {
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, request.CardId))
            {
                return Response.Failure<EditDateResponse>(OperationMessages.DoNotHavePermissionForEditDateCard);
            }
            var cardId = request.CardId;
            var startDate = request.startDate;
            var endDate = request.endDate;
            var card = await _cardRepository.FindAsync(cardId);

            var cardDate = CardDates.Create(startDate, endDate);
            card.ChangeDate(cardDate);
            await _unitOfWork.SaveChangesAsync();

            return Response.SuccessWithBody<EditDateResponse>(new
            {
                CardId = cardId
            }, OperationMessages.EditedCardDateSuccessfully);
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
