using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Domain.Cards
{
    public sealed class CardDates : Entity
    {
        public Guid CardId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime DeadDate { get; private set; }

        private CardDates() : base(Guid.Empty)
        {
        }

        private CardDates(
            Guid id,
            Guid cardId,
            DateTime startDate,
            DateTime deadDate) : base(id)
        {
            CardId = cardId;
            StartDate = startDate;
            DeadDate = deadDate;
        }

        public static CardDates Create(
            Guid id,
            Guid cardId,
            DateTime startDate,
            DateTime deadDate)
        {
            return new CardDates(id, cardId, startDate, deadDate);
        }
    }
}
