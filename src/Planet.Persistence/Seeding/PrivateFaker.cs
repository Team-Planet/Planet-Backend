using Bogus;

namespace Planet.Persistence.Seeding
{
    internal class PrivateFaker<T> : Faker<T> where T : class
    {
        public PrivateFaker(string locale) : base(locale)
        {
        }

        public PrivateFaker<T> UsePrivateConstructor()
        {
            return base.CustomInstantiator(f => Activator.CreateInstance(typeof(T), nonPublic: true) as T)
               as PrivateFaker<T>;
        }

        public PrivateFaker<T> RuleForPrivate<TProperty>(string propertyName, Func<Faker, TProperty> setter)
        {
            base.RuleFor(propertyName, setter);
            return this;
        }
    }
}
