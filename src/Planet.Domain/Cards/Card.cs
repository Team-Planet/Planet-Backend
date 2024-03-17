using Planet.Domain.Boards;
using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Domain.Cards
{
    public sealed class Card : Entity , IAggregateRoot
    {
        public CardTitle Title { get; private set; }
        public CardDescription Description { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid ListId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public Guid? AssignedId { get; private set; } 
        public int Order { get; private set; }
        public bool IsDeleted { get; private set; }

        private Card() : base(Guid.Empty)
        {
        }

        private Card(
           Guid id,
           CardTitle title,
           CardDescription description,
           Guid ownerId,
           Guid listId,
           DateTime createdDate,
           Guid? assignedId,
           int order,
           bool isDeleted) : base(id)

        {
            Title = title;
            Description = description;
            OwnerId = ownerId;
            ListId = listId;
            CreatedDate = createdDate;
            AssignedId = assignedId;
            Order = order;
            IsDeleted = isDeleted;
        }

        public static Card Create(
            Guid id,
            CardTitle title,
            CardDescription description,
            Guid ownerId,
            Guid listId,
            DateTime createdDate,
            Guid? assignedId,
            int order,
            bool isDeleted)
        {
            return new Card(id, title, description, ownerId, listId, createdDate, assignedId, order, isDeleted);
        }

    }
}
