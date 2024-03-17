using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public sealed class CardDates : Entity
    {
        public Guid CardId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        private CardDates() : base(Guid.Empty)
        {
        }

        private CardDates(
            Guid id,
            Guid cardId,
            DateTime startDate,
            DateTime endDate) : base(id)
        {
            CardId = cardId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static CardDates Create(
            Guid id,
            Guid cardId,
            DateTime startDate,
            DateTime endDate)
        {
            return new CardDates(id, cardId, startDate, endDate);
        }
    }
}
