using Planet.Application.Common;
using Planet.Application.Features.Cards.Commands.EditCardDescription;

namespace Planet.Application.Features.Cards.Commands.EditDescription
{
    public class EditCardDescriptionCommand : CommandBase<EditCardDescriptionResponse>
    {
        public Guid CardId { get; init; }
        public string Description { get; init; }
    }
}