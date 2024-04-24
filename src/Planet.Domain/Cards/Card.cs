using Planet.Domain.SharedKernel;
using System.Collections.Generic;

namespace Planet.Domain.Cards
{
    public sealed class Card : Entity, IAggregateRoot
    {
        public CardTitle Title { get; private set; }
        public CardDates Dates { get; private set; }
        public CardDescription Description { get; private set; }
        public Guid ListId { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid? AssignedToId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public int Order { get; private set; }
        public bool IsDeleted { get; private set; }

        public IReadOnlyList<CardCheckList> CheckLists => _checkLists?.ToList();
        public IReadOnlyList<CardLabel> Labels => _labels?.ToList();
        public IReadOnlyList<CardComment> Comments => _comments?.ToList();

        private IList<CardCheckList> _checkLists = new List<CardCheckList>();
        private IList<CardLabel> _labels = new List<CardLabel>();
        private IList<CardComment> _comments = new List<CardComment>();

        private Card() : base(Guid.Empty) { }

        private Card(
           Guid id,
           CardTitle title,
           CardDescription description,
           Guid ownerId,
           Guid listId,
           DateTime createdDate,
           Guid? assignedToId,
           int order,
           bool isDeleted) : base(id)

        {
            Title = title;
            Description = description;
            OwnerId = ownerId;
            ListId = listId;
            CreatedDate = createdDate;
            AssignedToId = assignedToId;
            Order = order;
            IsDeleted = isDeleted;
        }

        private Card(Guid id, Guid listId, CardTitle title, Guid ownerId, DateTime createdDate) : base(id)
        {
            Title = title;
            OwnerId = ownerId;
            ListId = listId;
            CreatedDate = createdDate;
            Description = CardDescription.Create(string.Empty);
        }

        public static Card Create(Guid id, Guid listId, CardTitle title, Guid ownerId, DateTime createdDate)
        {
            return new Card(id, listId, title, ownerId, createdDate);
        }

        public static Card Create(
            Guid id,
            CardTitle title,
            CardDescription description,
            Guid ownerId,
            Guid listId,
            DateTime createdDate,
            Guid? assignedToId,
            int order,
            bool isDeleted)
        {
            return new Card(id, title, description, ownerId, listId, createdDate, assignedToId, order, isDeleted);
        }

        public void ChangeCardDescription (CardDescription description)
        {
            Description = description;
        }
        public void AddLabel(CardLabel label)
        {
            _labels.Add(label);
        }
        public void ChangeDate(CardDates date)
        {
            Dates = date;
        }
    }
}
