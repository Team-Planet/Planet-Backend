using Planet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Queries.GetCardInfo
{
    public sealed class GetCardInfoQuery : QueryBase<GetCardInfoResponse>
    {
        public Guid CardId { get; init; }
    }
}
