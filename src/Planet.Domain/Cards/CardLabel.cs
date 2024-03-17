using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Domain.Cards
{
    public sealed class CardLabel : Entity
    {
        public Guid CardId { get; private set; }
        public Guid BoardLabelId { get; private set; }

        private CardLabel() : base(Guid.Empty)
        {
        }

        private CardLabel(
            Guid id,
            Guid cardId,
            Guid boardLabelId) : base(id)
        {
            CardId = cardId;
            BoardLabelId = boardLabelId;
        }

        public static CardLabel Create(
            Guid id,
            Guid cardId,
            Guid boardLabelId)
        {
            return new CardLabel(id, cardId, boardLabelId);
        }
    }
}
