using Bogus;
using Planet.Domain.Users;

namespace Planet.Persistence.Seeding
{
    public class UserStore
    {
        private static readonly Guid[] userIds = new Guid[]
    {
        new Guid("82cf02f0-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02f1-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02f2-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02f3-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02f4-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02f5-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02f6-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02f7-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02f8-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02f9-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02fa-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02fb-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02fc-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02fd-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02fe-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf02ff-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0300-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0301-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0302-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0303-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0304-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0305-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0306-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0307-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0308-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0309-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf030a-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf030b-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf030c-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf030d-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf030e-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf030f-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0310-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0311-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0312-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0313-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0314-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0315-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0316-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0317-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0318-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0319-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf031a-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf031b-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf031c-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf031d-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf031e-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf031f-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0320-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0321-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0322-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0323-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0324-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0325-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0326-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0327-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0328-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0329-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf032a-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf032b-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf032c-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf032d-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf032e-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf032f-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0330-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0331-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0332-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0333-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0334-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0335-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0336-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0337-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0338-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0339-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf033a-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf033b-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf033c-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf033d-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf033e-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf033f-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0340-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0341-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0342-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0343-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0344-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0345-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0346-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0347-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0348-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0349-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf034a-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf034b-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf034c-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf034d-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf034e-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf034f-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0350-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0351-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0352-e6e8-11ee-bd57-9dd06c6c36a5"),
        new Guid("82cf0353-e6e8-11ee-bd57-9dd06c6c36a5")
};

        public static List<User> GetUsers()
        {
            Faker faker = new Faker();
            faker.Locale = "TR";
            List<User> users = new List<User>();
            var email = faker.Internet.Email();
            var password = faker.Internet.Password();
            var firstname = faker.Name.FirstName();
            var lastname = faker.Name.LastName();
            var createdday = faker.Date.Past();
            var isactive = faker.Random.Bool();

            users.Add(User.Create(userIds[0], email, password, firstName, lastName, createdday, isactive))
;        }
    }
}
