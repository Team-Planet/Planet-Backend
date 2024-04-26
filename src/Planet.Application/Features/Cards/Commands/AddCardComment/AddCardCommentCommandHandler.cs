using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Resources.OperationResources;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Cards.Commands.AddCardComment
{
    internal class AddCardCommentCommandHandler : RequestHandlerBase<AddCardCommentCommand, AddCardCommentResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public AddCardCommentCommandHandler(ICardRepository cardRepository, IUnitOfWork unitOfWork, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _boardRepository = boardRepository;
        }
        public override async Task<AddCardCommentResponse> Handle(AddCardCommentCommand request, CancellationToken cancellationToken)
        {
            if (!await HasPermissionAsync(BoardPermissions.CreateAndEditCard, request.CardId))
            {
                return Response.Failure<AddCardCommentResponse>(OperationMessages.DoNotHavePermissionForEditCardComment);
            }
            var id = Guid.NewGuid();
            var userId = _userService.GetUserId();
            var cardId = request.CardId;
            var comment = CardCommentContent.Create(request.Comment);
            var card = await _cardRepository.FindAsync(cardId);

            var cardComment = CardComment.Create(id, userId, comment, cardId);
            card.AddComment(cardComment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Response.SuccessWithBody<AddCardCommentResponse>(new
            {
                CardId = cardId,
                Comment = comment.Value,
                CommentId = cardComment.Id
            }, OperationMessages.AddedCommentToCardSuccessfully);
        }
        private async Task<bool> HasPermissionAsync(BoardPermissions permission, Guid cardId)
        {
            var userId = _userService.GetUserId();
            return await _boardRepository.HasPermissionAsync(permission, cardId, userId);
        }

    }
}
