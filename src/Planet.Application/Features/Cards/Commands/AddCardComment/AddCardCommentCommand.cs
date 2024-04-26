using Planet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Commands.AddCardComment
{
    public class AddCardCommentCommand: CommandBase<AddCardCommentResponse>
    {
        public Guid CardId { get; init; }
        public string Comment { get; init; }
    }
}
