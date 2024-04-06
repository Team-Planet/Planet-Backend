using MediatR;
using Planet.Domain.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.Commands.AddMember
{
    public record AddMemberCommand(Guid UserId, Guid BoardId, BoardPermissions Permissions) : IRequest<AddMemberResponse>;


}
