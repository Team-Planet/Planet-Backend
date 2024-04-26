using Planet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Commands.AddCardCheckList
{
    public class AddCardCheckListCommand : CommandBase<AddCardCheckListResponse>
    {
        public Guid CardId { get; init; }
        public string Title { get; init; }

    }
}
