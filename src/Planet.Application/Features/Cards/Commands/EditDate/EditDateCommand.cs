using Planet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Commands.EditDate
{
    public class EditDateCommand : CommandBase<EditDateResponse>
    {
        public Guid CardId { get; init; }
        public DateTime startDate { get; init; }
        public DateTime endDate { get; init; }
    }
}
