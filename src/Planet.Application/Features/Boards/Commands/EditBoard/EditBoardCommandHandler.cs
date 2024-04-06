using MediatR;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.Commands.EditBoard
{
    internal class EditBoardCommandHandler : IRequestHandler<EditBoardCommand, EditBoardResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EditBoardCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EditBoardResponse> Handle(EditBoardCommand request, CancellationToken cancellationToken)
        {
            var boardId = request.BoardId;
            var title = BoardTitle.Create(request.Title);
            var description = BoardDescription.Create(request.Description);

            var board = await _boardRepository.FindAsync(boardId);

            if (board == null)
            {
                throw new InvalidOperationException("Board not found.");
            }

            board.ChangeBoardTitle(title);
            board.ChangeBoardDescription(description);

            await _unitOfWork.SaveChangesAsync();

            return new EditBoardResponse(boardId, title, description);
        }
    }
}
