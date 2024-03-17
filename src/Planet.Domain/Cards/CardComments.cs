using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public sealed class CardComments : Entity
    {
        public Guid UserId { get; private set; }
        public CardCommentContent Content { get; private set; }
        public Guid CardId { get; private set; }

        private CardComments() : base(Guid.Empty)
        {
        }
        private CardComments(
          Guid id,
          Guid userId,
          CardCommentContent content,
          Guid cardId) : base(id)
        {
            UserId = userId;
            Content = content;
            CardId = cardId;
        }
        public static CardComments Create(
           Guid id,
           Guid userId,
           CardCommentContent content,
           Guid cardId)
        {
            return new CardComments(id, userId, content, cardId);
        }


    } 
    
}
