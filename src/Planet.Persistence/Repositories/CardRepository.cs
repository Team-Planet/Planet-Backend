using Dapper;
using Microsoft.EntityFrameworkCore;
using Planet.Application.Models.Boards;
using Planet.Application.Models.Cards;
using Planet.Application.Services.Repositories;
using Planet.Application.Services.SqlConnection;
using Planet.Domain.Cards;
using Planet.Persistence.Contexts;
using System.Collections.Immutable;

namespace Planet.Persistence.Repositories
{
    public sealed class CardRepository : ICardRepository
    {
        private readonly PlanetContext _context;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CardRepository(PlanetContext context, ISqlConnectionFactory sqlConnectionFactory)
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

        public Task<Card> FindListIdByCardAsync(Guid id)
        {
            return _context.Cards.SingleOrDefaultAsync(c => c.Id == id);
        }
        public async Task<CardModel> GetCardInfo(Guid cardId)
        {
            string sql = @"
            SELECT c.Title, c.Description,
            c.ListId, c.OwnerId, c.AssignedToId,
            c.CreatedDate, c.IsDeleted, c.[Order] FROM Cards c
            WHERE c.Id = @CardId

            SELECT ccl.Id, ccl.Title, ccli.Id as ItemId, ccli.Content, ccli.IsChecked FROM CardCheckLists ccl
            INNER JOIN Cards c ON c.Id = ccl.CardId
            INNER JOIN CardCheckListItems ccli ON ccli.CheckListId = ccl.Id
            WHERE c.Id = @CardId

            SELECT bl.Id, bl.Title, bl.ColorCode, bl.IsActive FROM CardLabels cl
            INNER JOIN BoardLabels bl ON bl.Id = cl.BoardLabelId
            WHERE cl.CardId = @CardId

            SELECT cc.Id, cc.Content, u.Id as UserId, CONCAT(u.FirstName,' ',u.LastName) as FullName FROM CardComments cc
            INNER JOIN Users u ON u.Id = cc.UserId
            WHERE cc.CardId = @CardId
            ";

            using var connection = _sqlConnectionFactory.GetConnection();

            var gridReader = await connection.QueryMultipleAsync(sql, new { CardId = cardId });
            var cardModel = await gridReader.ReadFirstOrDefaultAsync<CardModel>();
            cardModel.CheckLists = (await gridReader.ReadAsync<CardCheckListModel>()).ToList();
            cardModel.Labels = (await gridReader.ReadAsync<CardLabelModel>()).ToList();
            cardModel.Comments = (await gridReader.ReadAsync<CardCommentModel>()).ToList();

            return cardModel;
        }
    }
}
