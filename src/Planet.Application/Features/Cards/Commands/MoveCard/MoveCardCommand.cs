using Planet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Commands.MoveTo
{
    public class MoveCardCommand : CommandBase<MoveCardResponse>
    {
        public Guid CardId { get; init; }
        public Guid NewListId { get; init; }
        public int NewOrder { get; init; }
    }
}
