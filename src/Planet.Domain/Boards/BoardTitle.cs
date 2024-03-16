using Planet.Domain.SharedKernel;

namespace Planet.Domain.Boards
{
    public record BoardTitle
    {
        public string Value { get; init; }

        private BoardTitle() { }

        private BoardTitle(string title)
        {
            Value = title;
        }

        public static BoardTitle Create(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new DomainException("BoardTitle.NullOrWhiteSpace", "Başlık boş olamaz!");
            }

            return new BoardTitle(title);
        }
    }
}
