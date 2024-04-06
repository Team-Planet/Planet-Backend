using MediatR;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.AddMember
{
    internal class AddMemberCommandHandler : IRequestHandler<AddMemberCommand, AddMemberResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddMemberCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddMemberResponse> Handle(AddMemberCommand request, CancellationToken cancellationToken)
        {
            var boardId = request.BoardId;
            var userId = request.UserId;
            var permissions = request.Permissions;

            var board = await _boardRepository.FindAsync(boardId);

            if (board == null)
            {
                throw new InvalidOperationException("Board not found.");
            }

            var newMember = BoardMember.Create(
                userId,
                boardId,
                permissions,
                DateTime.Now,
                true
            );

            board.AddMember(newMember);

            await _unitOfWork.SaveChangesAsync();

            return new AddMemberResponse(newMember);
        }
    }
}
