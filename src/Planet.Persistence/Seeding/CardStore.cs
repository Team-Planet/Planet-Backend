using Planet.Domain.Boards;
using Planet.Domain.Cards;
using System;

namespace Planet.Persistence.Seeding
{
    public class CardStore
    {
        private static readonly Guid[] cardIds = new Guid[]
        {
        new Guid("5a76ae90-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae91-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae92-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae93-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae94-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae95-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae96-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae97-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae98-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae99-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae9a-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae9b-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae9c-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae9d-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae9e-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76ae9f-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea0-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea1-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea2-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea3-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea4-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea5-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea6-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea7-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea8-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aea9-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeaa-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeab-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeac-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aead-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeae-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeaf-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb0-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb1-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb2-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb3-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb4-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb5-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb6-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb7-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb8-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeb9-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeba-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aebb-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aebc-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aebd-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aebe-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aebf-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec0-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec1-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec2-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec3-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec4-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec5-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec6-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec7-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec8-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aec9-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeca-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aecb-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aecc-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aecd-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aece-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aecf-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed0-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed1-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed2-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed3-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed4-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed5-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed6-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed7-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed8-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aed9-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeda-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aedb-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aedc-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aedd-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aede-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aedf-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee0-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee1-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee2-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee3-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee4-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee5-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee6-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee7-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee8-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aee9-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeea-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeeb-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeec-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeed-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeee-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aeef-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aef0-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aef1-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aef2-e763-11ee-a057-c7d96c4d17af"),
        new Guid("5a76aef3-e763-11ee-a057-c7d96c4d17af"),
        };
        private static readonly Guid[] commentIds = new Guid[]
        {
        new Guid("e8c8cf70-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf71-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf72-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf73-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf74-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf75-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf76-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf77-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf78-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf79-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf7a-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf7b-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf7c-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf7d-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf7e-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf7f-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf80-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf81-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf82-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf83-e9de-11ee-976b-35cf0f185f86")
    };
        private static readonly Guid[] checkListIds = new Guid[]
        {
        new Guid("e8c8cf84-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf85-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf86-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf87-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf88-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf89-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf8a-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf8b-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf8c-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf8d-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf8e-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf8f-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf90-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf91-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf92-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf93-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf94-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf95-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf96-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf97-e9de-11ee-976b-35cf0f185f86"),
        new Guid("e8c8cf98-e9de-11ee-976b-35cf0f185f86")
    }
        private static readonly Guid[] checkListItemIds = new Guid[]
        {
         new Guid("f2421ff0-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff1-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff2-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff3-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff4-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff5-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff6-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff7-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff8-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ff9-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffa-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffb-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffc-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffd-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421ffe-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2421fff-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2422000-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2422001-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2422002-e9e0-11ee-976b-35cf0f185f86"),
         new Guid("f2422003-e9e0-11ee-976b-35cf0f185f86")
    };


        public static List<Card> GetCards(List<IGrouping<Guid, BoardMember>> memberGroups, List<IGrouping<Guid, BoardList>> listGroups)
        {
            int index = 0;
            Guid boardId = Guid.Empty;

            var cardFaker = new PrivateFaker<Card>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(c => c.Id, f => cardIds[index++])
                .RuleFor(c => c.Title, f => CardTitle.Create(f.Lorem.Sentence(3)))
                .RuleFor(c => c.Description, f => CardDescription.Create(f.Lorem.Sentence(5)))
                .RuleFor(c => c.ListId, f =>
                {
                    var listGroup = listGroups[f.Random.Number(0, listGroups.Count - 1)];
                    boardId = listGroup.Key;
                    return listGroup.ToList()[f.Random.Number(0, listGroup.Count() - 1)].Id;
                })
                .RuleFor(c => c.OwnerId, (f, c) =>
                {
                    var listGroup = listGroups.FirstOrDefault(g => g.Any(l => l.Id == c.ListId));
                    var memberGroup = memberGroups.FirstOrDefault(g => g.Key == listGroup.First().BoardId);
                    return memberGroup.ToList()[f.Random.Number(0, memberGroup.Count() - 1)].UserId;
                })
                .RuleFor(c => c.CreatedDate, f => DateTime.Now)
                .RuleFor(c => c.AssignedToId, (f, c) =>
                {
                    var listGroup = listGroups.FirstOrDefault(g => g.Any(l => l.Id == c.ListId));
                    var memberGroup = memberGroups.FirstOrDefault(g => g.Key == listGroup.First().BoardId);
                    var memberId = memberGroup.ToList()[f.Random.Number(0, memberGroup.Count() - 1)].UserId;
                    return f.Random.Bool(0.75f) ? memberId : null;
                })
                .RuleFor(c => c.Order, f => f.Random.Number(1, 100))
                .RuleFor(c => c.IsDeleted, f => f.Random.Bool(0.05f));

            var cards = cardFaker.Generate(cardIds.Length);

            return cards;


        }

        public static List<CardComment> GetComments(List<Card> cards, List<IGrouping<Guid, BoardMember>> memberGroups)
        {
            int index = 0;
            var commentFaker = new PrivateFaker<CardComment>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(c => c.Id, f => commentIds[index++])
                //.RuleFor(c => c.CardId, f => cards[f.Random.Number(0, cards.Count - 1)].Id)
                //.RuleFor(c => c.UserId, (f, c) =>
                //{
                //    var card = cards.FirstOrDefault(c => c.Id == c.CardId);
                //    var memberGroup = memberGroups.FirstOrDefault(g => g.Key == card.OwnerId);
                //    return memberGroup.ToList()[f.Random.Number(0, memberGroup.Count() - 1)].UserId;
                //})
                .RuleFor(c => c.Content, f => CardCommentContent.Create(f.Lorem.Sentence(5)));


            var comments = commentFaker.Generate(commentIds.Length);

            return comments;
        }

        public static List<CardCheckList> GetCheckLists(List<Card> cards)
        {
            int index = 0;
            var checkListFaker = new PrivateFaker<CardCheckList>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(c => c.Id, f => checkListIds[index++])
                //.RuleFor(c => c.CardId, f => cards[f.Random.Number(0, cards.Count - 1)].Id)
                .RuleFor(c => c.CardTitle, f => CardTitle.Create(f.Lorem.Sentence(3)));

            var checkLists = checkListFaker.Generate(checkListIds.Length);

            return checkLists;
        }

        public static List<CardCheckListItem> GetCheckListItems(List<CardCheckList> checkLists)
        {
            int index = 0;
            var checkListItemFaker = new PrivateFaker<CardCheckListItem>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(c => c.Id, f => checkListItemIds[index++])
                //.RuleFor(c => c.CheckListId, f => checkLists[f.Random.Number(0, checkLists.Count - 1)].Id)
                .RuleFor(c => c.Content, f => CardCheckListItemContent.Create(f.Lorem.Sentence(3)))
                .RuleFor(c => c.IsChecked, f => f.Random.Bool(0.7f));

            var checkListItems = checkListItemFaker.Generate(checkListItemIds.Length);

            return checkListItems;
        }

    }
}
