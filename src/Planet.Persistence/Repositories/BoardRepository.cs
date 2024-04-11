using Dapper;
using IdentityModel.Client;
using Microsoft.EntityFrameworkCore;
using Planet.Application.Common;
using Planet.Application.Features.Boards.Queries.GetUserBoards;
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

        public async Task<Pagination<UserBoardModel>> GetUserBoardsAsync(GetUserBoardsQuery query, Guid userId)
        {
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(query);
            parameters.Add("@UserId", userId);

            string sql = @"
            SELECT COUNT(*) FROM BoardMembers bm
            INNER JOIN Boards b ON b.Id = bm.BoardId
            WHERE bm.UserId = @UserId AND b.IsActive = 1 AND bm.IsActive = 1

            SELECT b.Id, b.Title FROM BoardMembers bm
            INNER JOIN Boards b ON b.Id = bm.BoardId
            WHERE bm.UserId = @UserId AND b.IsActive = 1 AND bm.IsActive = 1
            ORDER BY b.Title ASC
            OFFSET @PageSize * (@CurrentPage - 1) ROWS
            FETCH NEXT @PageSize ROWS ONLY
            ";

            using var connection = _sqlConnectionFactory.GetConnection();
            var gridReader = await connection.QueryMultipleAsync(sql, parameters);

            int recordCount = await gridReader.ReadFirstOrDefaultAsync<int>();
            var items = await gridReader.ReadAsync<UserBoardModel>();

            return new Pagination<UserBoardModel>
            {
                CurrentPage = query.CurrentPage,
                PageSize = query.PageSize,
                RecordCount = recordCount,
                Items = items.ToList()
            };

        }
    }
}
