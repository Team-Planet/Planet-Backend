using Planet.Domain.Boards;
using Planet.Domain.SharedKernel;

namespace Planet.Domain.Cards
{
    public sealed class Card : Entity , IAggregateRoot
    {
        public CardTitle Title { get; private set; }
        public CardDescription Description { get; private set; }
        public Guid ListId { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid? AssignedToId { get; private set; } 
        public DateTime CreatedDate { get; private set; }
        public int Order { get; private set; }
        public bool IsDeleted { get; private set; }

        public IReadOnlyList<CardCheckList> CheckLists => _checkLists?.ToList();
        public IReadOnlyList<CardLabel> Labels => _labels?.ToList();

        private IList<CardCheckList> _checkLists = new List<CardCheckList>();
        private IList<CardLabel> _labels = new List<CardLabel>();

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

    }
}
