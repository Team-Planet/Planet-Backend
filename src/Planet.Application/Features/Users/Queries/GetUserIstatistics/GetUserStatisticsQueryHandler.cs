using Planet.Application.Common;
using Planet.Application.Services.Repositories;

namespace Planet.Application.Features.Users.Queries.GetUserIstatistics
{
    public sealed class GetUserStatisticsQueryHandler : RequestHandlerBase<GetUserStatisticsQuery, GetUserStatisticsResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserStatisticsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async override Task<GetUserStatisticsResponse> Handle(GetUserStatisticsQuery request, CancellationToken cancellationToken)
        {
            var userStatistics = await _userRepository.GetUserStatistics(request.UserId);

            return Response.SuccessWithBody<GetUserStatisticsResponse>(userStatistics);
        }
    }
}
