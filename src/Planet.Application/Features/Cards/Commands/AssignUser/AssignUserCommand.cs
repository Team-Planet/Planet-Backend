using Planet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Commands.AssignUser
{
    public class AssignUserCommand : CommandBase<AssignUserResponse>
    {
        public Guid CardId { get; init; }
        public Guid UserId { get; init; }
    }
    
}
