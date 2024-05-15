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
using Planet.Application.Features.Cards.Queries.GetCards;

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

        public async Task<Pagination<CardListModel>> GetCardsAsync(GetCardsQuery query, Guid listId)
        {
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(query);
            parameters.Add("@ListId", listId);

            string sql = @"
            SELECT c.Id, C.title, c.[Order], u.Id UserId, u.FirstName, u.LastName
            FROM Planet.dbo.Cards c Left Join Planet.dbo.Users u ON u.Id = c.AssignedToId
            WHERE c.ListId = @ListId
            ORDER BY c.[Order] ASC

            SELECT bl.Title, bl.ColorCode, cl.CardId From Planet.dbo.CardLabels cl
            Inner Join Planet.dbo.BoardLabels bl ON bl.Id = cl.BoardLabelId
            WHERE cl.CardId IN(SELECT c.Id from Planet.dbo.Cards c WHERE c.ListId = @ListId)";


            using var connection = _sqlConnectionFactory.GetConnection();
            var gridReader = await connection.QueryMultipleAsync(sql, parameters);

            int recordCount = await gridReader.ReadFirstOrDefaultAsync<int>();
            var items = await gridReader.ReadAsync<CardListModel>();

            return new Pagination<UserBoardModel>
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
