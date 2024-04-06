using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.Commands.RemoveMember
{
    public record RemoveMemberCommand(Guid UserId, Guid BoardId) : IRequest<RemoveMemberResponse>;

}
