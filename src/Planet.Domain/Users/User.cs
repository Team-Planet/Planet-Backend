using Planet.Domain.Shared;
using Planet.Domain.SharedKernel;

namespace Planet.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; private set; }

        private User() : base(Guid.Empty) { }

        public void ChangeActivity(bool activity)
        {
            IsActive = activity;
        } 
    }
}
