using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public sealed class CardCheckList : Entity
    {
        public Guid CardId { get; private set; }
        public CardTitle CardTitle { get; private set; }
        public IReadOnlyList<CardCheckListItem> Members => _items?.ToList();

        private IList<CardCheckListItem> _items = new List<CardCheckListItem>();
        private CardCheckList(
            Guid id,
            Guid cardId, 
            CardTitle cardTitle) : base(Guid.Empty)
        {
            CardId = cardId;
            CardTitle = cardTitle;
        }
        public static CardCheckList Create(
            Guid id,
            Guid cardId,
            CardTitle cardTitle
            )
        {
            return new CardCheckList( id, cardId, cardTitle );
        }
    }
}
