using Planet.Domain.SharedKernel;

namespace Planet.Domain.Boards
{
    public sealed class BoardMember : Entity
    {
        public Guid UserId { get; private set; }
        public Guid BoardId { get; private set; }
        public BoardPermissions Permissions { get; private set; }
        public DateTime JoinedDate { get; private set; }
        public bool IsActive { get; private set; }

        private BoardMember() : base(Guid.Empty) { }

        private BoardMember(
            Guid id,
            Guid userId,
            Guid boardId,
            BoardPermissions permissions,
            DateTime joinedDate,
            bool isActive) : base(id)
        {
            UserId = userId;
            BoardId = boardId;
            Permissions = permissions;
            JoinedDate = joinedDate;
            IsActive = isActive;
        }

        public static BoardMember Create(
            Guid id,
            Guid userId,
            Guid boardId,
            BoardPermissions permissions,
            DateTime joinedDate,
            bool isActive)
        {
            return new BoardMember(id, userId, boardId, permissions, joinedDate, isActive);
        }
    }
}
