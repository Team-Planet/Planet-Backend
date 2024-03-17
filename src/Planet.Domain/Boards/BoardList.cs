using Planet.Domain.SharedKernel;

namespace Planet.Domain.Boards
{
    public sealed class BoardList : Entity
    {
        public Guid BoardId { get; private set; }
        public BoardTitle Title { get; private set; }
        public int Order { get; private set; }
        private BoardList(): base(Guid.Empty) { }

        private BoardList(
            Guid id,
            Guid boardId,
            BoardTitle title,
            int order) : base(id)
        {
            BoardId = boardId;
            Title = title;
            Order = order;
        }
        public static BoardList Create(
            Guid id,
            Guid boardId,
            BoardTitle title,
            int order)
        {
            return new BoardList(id, boardId, title, order);
        }
    }
}
