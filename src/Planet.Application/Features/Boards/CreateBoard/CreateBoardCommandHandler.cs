using MediatR;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.SharedKernel;

namespace Planet.Application.Features.Boards.CreateBoard
{
    internal class CreateBoardCommandHandler : IRequestHandler<CreateBoardCommand, CreateBoardResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public CreateBoardCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork, IUserService userService)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }
        public async Task<CreateBoardResponse> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
        {
            var title = BoardTitle.Create(request.Title);
            var description = BoardDescription.Create(request.Description);
            var modules = (BoardModules)request.BoardModules;
            var createdDate = DateTime.Now;
            var boardId = Guid.NewGuid();
            var ownerId = _userService.GetUserId();

            if(ownerId == Guid.Empty)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            var board = Board.Create(boardId, title, description, modules, createdDate, ownerId);

            await _boardRepository.CreateAsync(board);
            await _unitOfWork.SaveChangesAsync();
            return new CreateBoardResponse(board);
        }
    }
}
