using Planet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Commands.EditCardCheckListTitle
{
    public class EditCardCheckListTitleCommand: CommandBase<EditCardCheckListTitleResponse>
    {
        public Guid CardId { get; init; }
        public Guid CheckListId { get; init; }
        public string NewTitle { get; init; }
    }
}
