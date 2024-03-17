namespace Planet.Domain.Cards
{
    public sealed record CardLabel
    {
        public Guid CardId { get; private set; }
        public Guid BoardLabelId { get; private set; }

        private CardLabel()
        {
        }

        private CardLabel(
            Guid cardId,
            Guid boardLabelId)
        {
            CardId = cardId;
            BoardLabelId = boardLabelId;
        }

        public static CardLabel Create(
            Guid cardId,
            Guid boardLabelId)
        {
            return new CardLabel(cardId, boardLabelId);
        }
    }
}
