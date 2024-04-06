using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Features.Boards.Commands.AcceptInvitation;
using Planet.Application.Features.Boards.Commands.AddList;
using Planet.Application.Features.Boards.Commands.AddMember;
using Planet.Application.Features.Boards.Commands.CreateBoard;
using Planet.Application.Features.Boards.Commands.EditBoard;
using Planet.Application.Features.Boards.Commands.InviteMember;
using Planet.Application.Features.Boards.Commands.RemoveList;
using Planet.Application.Features.Boards.Commands.RemoveMember;
using Planet.Application.Features.Boards.Queries.GetUserBoards;

namespace Planet.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BoardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBoardCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBoardCommand command,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(AddMemberCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveMember(RemoveMemberCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddList(AddListCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveList(RemoveListCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InviteMember(InviteMemberCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet("{invitationKey}")]
        public async Task<IActionResult> AcceptInvitation(string invitationKey, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new AcceptInvitationCommand(invitationKey), cancellationToken);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBoards(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetUserBoardsQuery(), cancellationToken);

            return Ok(response);
        }
    }
}
