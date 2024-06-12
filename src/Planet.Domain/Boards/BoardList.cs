using Planet.Domain.SharedKernel;

namespace Planet.Domain.Boards
{
    public sealed class BoardList : Entity, IAggregateRoot
    {
        public Guid BoardId { get; private set; }
        public BoardTitle Title { get; private set; }
        public decimal Order { get; private set; }
        private BoardList() : base(Guid.Empty) { }

        private BoardList(
            Guid id,
            Guid boardId,
            BoardTitle title,
            decimal order) : base(id)
        {
            BoardId = boardId;
            Title = title;
            Order = order;
        }
        public static BoardList Create(
            Guid id,
            Guid boardId,
            BoardTitle title,
            decimal order)
        {
            return new BoardList(id, boardId, title, order);
        }
    }
}
