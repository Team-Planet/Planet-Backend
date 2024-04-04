using MediatR;
using Planet.Application.Features.Boards.CreateBoard;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.AddList
{
    internal class AddListCommandHandler : IRequestHandler<AddListCommand, AddListResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddListCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddListResponse> Handle(AddListCommand request, CancellationToken cancellationToken)
        {
            var boardId = request.boardId;
            var title = BoardTitle.Create(request.title);
            var order = request.order;
            var listId = Guid.NewGuid();

            var boardList = BoardList.Create(listId, boardId, title, order);
            var board = await _boardRepository.FindAsync(boardId);
            board.AddList(boardList);
            await _unitOfWork.SaveChangesAsync();

            return new AddListResponse(boardList);
        }

    }
}
