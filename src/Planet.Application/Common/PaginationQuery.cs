namespace Planet.Application.Common
{
    public class PaginationQuery<TResponse> : QueryBase<TResponse> where TResponse : ResponseBase, new()
    {
        public int PageSize { get; init; }
        public int CurrentPage { get; init; }
    }
}
