namespace Planet.Domain.SharedKernel
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
