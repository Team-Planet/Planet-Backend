using Planet.Domain.SharedKernel;
namespace Planet.Domain.Boards
{
    public interface IBoardDomainRepository : IDomainRepository<Board>
    {
        Task<List<BoardList>> GetListsForBoardAsync(Guid boardId);
    }
}
