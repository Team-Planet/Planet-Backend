using MediatR.Wrappers;
using Planet.Application.Common;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Queries
{
    public sealed class GetCardsQueryHandler : RequestHandlerBase<GetCardsQuery, GetCardsResponse>
    {

        private readonly IUserService _userService;
        private readonly ICardRepository  _cardRepository;

        public GetCardsQueryHandler(IUserService userService, ICardRepository cardRepository)
        {
            _userService = userService;
            _cardRepository = cardRepository;
        }
        public override Task<GetCardsResponse> Handle(GetCardsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
