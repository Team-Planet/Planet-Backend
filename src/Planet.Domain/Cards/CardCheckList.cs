using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public sealed class CardCheckList : Entity
    {
        public Guid CardId { get; private set; }
        public CardTitle CardTitle { get; private set; }
        public IReadOnlyList<CardCheckListItem> Items => _items?.ToList();

        private IList<CardCheckListItem> _items = new List<CardCheckListItem>();

        private CardCheckList() : base(Guid.Empty) { }

        private CardCheckList(
            Guid id,
            Guid cardId,
            CardTitle cardTitle) : base(id)
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
            return new CardCheckList(id, cardId, cardTitle);
        }

        public void ChangeTitle ( CardTitle title )
        {
            CardTitle = title;
        }
    }
}
