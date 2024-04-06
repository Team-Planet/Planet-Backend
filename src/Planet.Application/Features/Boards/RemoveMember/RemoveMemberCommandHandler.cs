using MediatR;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.RemoveMember
{
    internal class RemoveMemberCommandHandler : IRequestHandler<RemoveMemberCommand, RemoveMemberResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveMemberCommandHandler(IBoardRepository boardRepository, IUnitOfWork unitOfWork)
        {
            _boardRepository = boardRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveMemberResponse> Handle(RemoveMemberCommand request, CancellationToken cancellationToken)
        {
            var boardId = request.BoardId;
            var userId = request.UserId;

            var board = await _boardRepository.FindAsync(boardId);
            var boardMember = board.Members.FirstOrDefault(m => m.UserId == userId);

            if (board == null)
            {
                throw new InvalidOperationException("Board not found.");
            }

            board.RemoveMember(boardMember);

            
            await _unitOfWork.SaveChangesAsync();

            
            return new RemoveMemberResponse(true);
        }
    }
}
