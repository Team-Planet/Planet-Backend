using Dapper;
using Microsoft.EntityFrameworkCore;
using Planet.Application.Common;
using Planet.Application.Features.Boards.Queries.GetUserBoards;
using Planet.Application.Models.Boards;
using Planet.Application.Models.Cards;
using Planet.Application.Services.Repositories;
using Planet.Application.Services.SqlConnection;
using Planet.Domain.Cards;
using Planet.Domain.Users;
using Planet.Persistence.Contexts;
using Planet.Application.Features.Cards.Queries.GetListCards;

namespace Planet.Persistence.Repositories
{
    public sealed class CardRepository : ICardRepository
    {
        private readonly PlanetContext _context;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CardRepository(PlanetContext context , ISqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task CreateAsync(Card entity)
        {
            await _context.Cards.AddAsync(entity);
        }

        public Task<Card> FindAsync(Guid id)
        {
            return _context.Cards.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Pagination<ListCardModel>> GetListCardsAsync(GetListCardsQuery query)
        {
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(query);

            string sql = @"
            SELECT COUNT(*)
            FROM Cards c
            WHERE c.ListId = @ListId

            SELECT c.Id, C.title, c.[Order], u.Id UserId, u.FirstName + ' ' + u.LastName FullName
            FROM Cards c LEFT JOIN Users u ON u.Id = c.AssignedToId
            WHERE c.ListId = @ListId
            ORDER BY c.[Order] ASC
            OFFSET @PageSize * (@CurrentPage - 1) ROWS
            FETCH NEXT @PageSize ROWS ONLY

            SELECT bl.Title, bl.ColorCode, cl.CardId FROM CardLabels cl
            INNER JOIN BoardLabels bl ON bl.Id = cl.BoardLabelId
            WHERE cl.CardId IN(
	            SELECT c.Id
	            FROM Cards c LEFT JOIN Users u ON u.Id = c.AssignedToId
	            WHERE c.ListId = @ListId
	            ORDER BY c.[Order] ASC
	            OFFSET @PageSize * (@CurrentPage - 1) ROWS
	            FETCH NEXT @PageSize ROWS ONLY
            )";


            using var connection = _sqlConnectionFactory.GetConnection();
            var gridReader = await connection.QueryMultipleAsync(sql, parameters);

            int recordCount = await gridReader.ReadFirstOrDefaultAsync<int>();
            var items = await gridReader.ReadAsync<ListCardModel>();
            var labels = await gridReader.ReadAsync<ListCardLabel>();
            
            foreach(var item in items)
            {
                item.Labels = labels.Where(l => item.Id == l.CardId).ToList();
            }

            return new Pagination<ListCardModel>
            {
                CurrentPage = query.CurrentPage,
                PageSize = query.PageSize,
                RecordCount = recordCount,
                Items = items.ToList()
            };

        }

        public Task<Card> FindListIdByCardAsync(Guid id)
        {
            return _context.Cards.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
