using Planet.Application.Common;

namespace Planet.Application.Features.Users.Queries.GetUserIstatistics
{
    public sealed class GetUserStatisticsQuery : QueryBase<GetUserStatisticsResponse>
    {
        public Guid UserId { get; init; }
    }
}
