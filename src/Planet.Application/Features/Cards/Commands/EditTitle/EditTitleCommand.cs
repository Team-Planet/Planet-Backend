using Planet.Application.Common;
using Planet.Domain.Cards;

namespace Planet.Application.Features.Cards.Commands.EditTitle
{
    public class EditTitleCommand : CommandBase<EditTitleResponse>
    {
        public Guid CardId { get; init; }
        public string Title { get; init; }
    }
}
