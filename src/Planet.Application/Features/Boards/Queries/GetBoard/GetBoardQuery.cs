using Planet.Application.Common;

namespace Planet.Application.Features.Boards.Queries.GetBoard
{
    public sealed class GetBoardQuery : CommandBase<GetBoardResponse>
    {
        public Guid BoardId { get; init; }
    }
}
