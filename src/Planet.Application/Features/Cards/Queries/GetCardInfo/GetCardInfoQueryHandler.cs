using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;

namespace Planet.Application.Features.Cards.Queries.GetCardInfo
{
    public sealed class GetCardInfoQueryHandler : RequestHandlerBase<GetCardInfoQuery, GetCardInfoResponse>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUserService _userService;
        private readonly IBoardRepository _boardRepository;

        public GetCardInfoQueryHandler(ICardRepository cardRepository, IUserService userService, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _userService = userService;
            _boardRepository = boardRepository;
        }

        public async override Task<GetCardInfoResponse> Handle(GetCardInfoQuery request, CancellationToken cancellationToken)
        {
            //var userId = _userService.GetUserId();
            //bool hasPermission = await _boardRepository.HasPermissionAsync(BoardPermissions.View, request.)

            var cardModel = await _cardRepository.GetCardInfo(request.CardId);

            return Response.SuccessWithBody<GetCardInfoResponse>(cardModel);
        }
    }
}
