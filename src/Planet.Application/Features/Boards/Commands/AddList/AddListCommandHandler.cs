using MediatR;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Boards.Commands.AddList
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
            var boardId = request.BoardId;
            var title = BoardTitle.Create(request.Title);
            var order = request.Order;
            var listId = Guid.NewGuid();
            var board = await _boardRepository.FindAsync(boardId);

            var boardList = BoardList.Create(listId, boardId, title, order);
            board.AddList(boardList);
            await _unitOfWork.SaveChangesAsync();

            return new AddListResponse(boardList);
        }

    }
}
