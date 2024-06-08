using Planet.Domain.Users;

namespace Planet.Application.Models.Users
{
    public sealed class UserModel
    {
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string RefreshToken { get; private set; }
        public DateTime? TokenExpireDate { get; private set; }
        public bool IsActive { get; private set; }
    }
    public sealed class UserStatisticsModel
    {
        public int BoardMemberCount { get; set; }
        public int CardCommentCount { get; set; }
        public int CardOwnerCount { get; set; }
        public int CardAssignedCount { get;  set; }

        public Dictionary<string, int> statistics = new Dictionary<string, int>
        {
            { "BoardMemberCount",  0},
            { "CardCommentCount", 0 },
            { "CardOwnerCount", 0 },
            { "CardAssignedCount", 0 }
        };
    }
}
