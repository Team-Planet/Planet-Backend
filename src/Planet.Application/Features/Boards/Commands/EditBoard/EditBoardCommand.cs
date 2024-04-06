using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.Commands.EditBoard
{
    public record EditBoardCommand(Guid BoardId, string Title, string Description) : IRequest<EditBoardResponse>;
}
