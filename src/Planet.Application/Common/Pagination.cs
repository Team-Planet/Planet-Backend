namespace Planet.Application.Common
{
    public sealed class Pagination<T>
    {
        public int RecordCount { get; init; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount => (int)Math.Ceiling((decimal)RecordCount / PageSize);
        public List<T> Items { get; init; }
    }
}
