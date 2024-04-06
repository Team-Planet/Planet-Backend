using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.CreateBoard
{
    public record CreateBoardCommand(
        string Title,
        string Description,
        byte BoardModules
        ) : IRequest<CreateBoardResponse>;
}
