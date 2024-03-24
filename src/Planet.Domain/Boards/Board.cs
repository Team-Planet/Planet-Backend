using Planet.Domain.SharedKernel;

namespace Planet.Domain.Boards
{
    public sealed class Board : Entity, IAggregateRoot
    {
        public BoardTitle Title { get; private set; }
        public BoardDescription Description { get; private set; }
        public BoardModules Modules { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; private set; }
        public Guid OwnerId { get; private set; }
        public IReadOnlyCollection<BoardMember> Members => _members?.ToList();
        public IReadOnlyCollection<BoardList> Lists => _lists?.ToList();
        public IReadOnlyCollection<BoardLabel> Labels => _labels?.ToList();

        private HashSet<BoardMember> _members = new();
        private HashSet<BoardLabel> _labels = new();
        private HashSet<BoardList> _lists = new();

        private Board() : base(Guid.Empty)
        {
        }

        private Board(Guid id,
            BoardTitle title,
            BoardDescription description,
            BoardModules modules,
            DateTime createdDate,
            bool isActive,
            Guid ownerId) : base(id)
        {
            Title = title;
            Description = description;
            Modules = modules;
            CreatedDate = createdDate;
            IsActive = isActive;
            OwnerId = ownerId;
        }



        public static Board Create(Guid id,
            BoardTitle title,
            BoardDescription description,
            BoardModules modules,
            DateTime createdDate,
            bool isActive,
            Guid ownerId)
        {
            return new Board(id, title, description, modules, createdDate, isActive, ownerId);
        }

        public void ChangeBoardTitle(BoardTitle title)
        {
            Title = title;
        }

        public void AddMember(BoardMember member)
        {
            _members.Add(member);
        }
    }
}
