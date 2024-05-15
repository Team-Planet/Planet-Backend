using Planet.Domain.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Planet.Application.Models.Cards.CardCheckListItemModel;

namespace Planet.Application.Models.Cards
{
    public sealed class CardModel
    {
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public Guid ListId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? AssignedToId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Order { get; private set; }
        public bool IsDeleted { get; set; }
        public List<CardCheckListModel> CheckLists { get; set; } = new();
        public List<CardLabelModel> Labels { get; set; } = new();
        public List<CardCommentModel> Comments { get; set; } = new();
    }
    public sealed class CardCheckListModel
    {
        public Guid CardId { get; set; }
        public string Title { get; set; }
        public List<CardCheckListItemModel> Items { get; set; } = new();
    }

    public sealed class CardCheckListQueryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid ItemId { get; set; }
        public string Content { get; set; }
        public bool IsChecked { get; set; }
    }

    public sealed class CardCheckListItemModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsChecked { get; set; }
    }
    public sealed class CardLabelModel
    {
        public string ColorCode { get; set; }
        public string Title { get; set; }
    }
    public sealed class CardCommentModel
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Content { get; set; }
    }
}
