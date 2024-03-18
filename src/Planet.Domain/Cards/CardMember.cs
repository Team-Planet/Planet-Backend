using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public sealed class CardMember : Entity
    {
        public Guid UserId { get; private set; }
        public Guid CardId { get; private set; }
        public DateTime JoinedDate { get; private set; }
        public bool IsActive { get; private set; }

        private CardMember() : base(Guid.Empty) { }

        private  CardMember(
            Guid id,
            Guid userId,
            Guid cardId,
            DateTime joinedDate,
            bool isActive) : base(id)
        {
            UserId = userId;
            CardId = cardId;
            JoinedDate = joinedDate;
            IsActive = isActive;
        }
        public static CardMember Create (
            Guid id,
            Guid userId,
            Guid cardId,
            DateTime joinedDate,
            bool isActive)
        {
            return new CardMember(id,userId, cardId, joinedDate, isActive);
        }
    }
}
