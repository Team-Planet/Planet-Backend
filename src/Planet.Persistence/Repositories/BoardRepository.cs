using Dapper;
using Microsoft.EntityFrameworkCore;
using Planet.Application.Models.Boards;
using Planet.Application.Services.Repositories;
using Planet.Application.Services.SqlConnection;
using Planet.Domain.Boards;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Repositories
{
    public sealed class BoardRepository : IBoardRepository
    {
        private readonly PlanetContext _context;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public BoardRepository(PlanetContext context, ISqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task CreateAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
        }
        public Task<Board> FindAsync(Guid id)
        {
            return _context.Boards.Include(b => b.Lists)
                .Include(b => b.Labels)
                .SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<UserBoardModel>> GetUserBoardsAsync(Guid userId)
        {
            string sql = @"
            SELECT b.Id, b.Title FROM BoardMembers bm
            INNER JOIN Boards b ON b.Id = bm.BoardId
            WHERE bm.UserId = @UserId AND b.IsActive = 1 AND bm.IsActive = 1
            ";

            using var connection = _sqlConnectionFactory.GetConnection();

            return (await connection.QueryAsync<UserBoardModel>(sql, new { UserId = userId })).ToList();

        }
    }
}
