using Planet.Domain.SharedKernel;
using System.Drawing;
namespace Planet.Domain.Boards
{
    public sealed class BoardLabels :Entity
    {
        public Guid BoardId { get; private set; }
        public Color Color { get; private set; }
        public BoardTitle Title { get; private set; }
        public bool IsActive { get; private set; }
        private BoardLabels() : base(Guid.Empty) { }
        private BoardLabels(
            Guid id,
            Guid boardId,
            Color color,
            BoardTitle title,
            bool isActive):base(id)
        {
            BoardId = boardId;
            Color = color;
            Title = title;
            IsActive = isActive;
        }
        public static BoardLabels Create(Guid id,
            Guid boardId,
            Color color,
            BoardTitle title,
            bool isActive)
        {
            return new BoardLabels(id,boardId, color, title, isActive);
        }
    }
}
