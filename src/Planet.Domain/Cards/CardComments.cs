using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Domain.Cards
{
    public sealed class CardComments : Entity
    {
        public Guid UserId { get; private set; }
        public CardCommentDescription Description { get; private set; }
        public Guid CardId { get; private set; }

        private CardComments() : base(Guid.Empty)
        {
        }
        private CardComments(
          Guid id,
          Guid userId,
          string description,
          Guid cardId) : base(id)
        {
            UserId = userId;
            Description = description;
            CardId = cardId;
        }
        public static CardComments Create(
           Guid id,
           Guid userId,
           string description,
           Guid cardId)
        {
            return new CardComments(id, userId, description, cardId);
        }


    } 
    
}
