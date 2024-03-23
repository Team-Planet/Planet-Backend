using Planet.Domain.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Card> GetCards()
        {
            int index = 0;
            var cardFaker = new PrivateFaker<Card>(locale: "tr")
                .UsePrivateConstructor()
                .RuleFor(c => c.Id, f => cardIds[index++])
                .RuleFor(c => c.Title, f => CardTitle.Create(f.Lorem.Sentence()))
                .RuleFor(c => c.Description, f => CardDescription.Create(f.Lorem.Paragraph()))
                .RuleFor(c => c.OwnerId, f => f.Random.Guid())
                .RuleFor(c => c.ListId, f => f.Random.Guid())
                .RuleFor(c => c.CreatedDate, f => DateTime.Now)
                .RuleFor(c => c.AssignedToId, f => f.Random.Guid())
                .RuleFor(c => c.Order, f => f.Random.Number(1, 100))
                .RuleFor(c => c.IsDeleted, f => f.Random.Bool(0.1f));

            var cards = cardFaker.Generate(cardIds.Length);

            return cards;


        }
    }
}
