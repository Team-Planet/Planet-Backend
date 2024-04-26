using Planet.Application.Common;

namespace Planet.Application.Features.Cards.Commands.EditDate
{
    public class EditDateCommand : CommandBase<EditDateResponse>
    {
        public Guid CardId { get; init; }
        public DateTime startDate { get; init; }
        public DateTime endDate { get; init; }
    }
}
