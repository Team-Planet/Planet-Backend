using MediatR;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Boards.Commands.RemoveList
{
    internal class RemoveListCommandHandler : IRequestHandler<RemoveListCommand, RemoveListResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveListCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveListResponse> Handle(RemoveListCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.FindAsync(request.BoardId);
            var boardList = board.Lists.FirstOrDefault(l => l.Id == request.BoardListId);
            board.RemoveList(boardList);


            await _unitOfWork.SaveChangesAsync();
            return new RemoveListResponse(request.BoardListId);
        }
    }
}
