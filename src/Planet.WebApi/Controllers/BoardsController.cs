using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Features.Boards.AddList;
using Planet.Application.Features.Boards.CreateBoard;
using Planet.Application.Features.Boards.RemoveList;

namespace Planet.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BoardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateBoardCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Edit()
        {
            return await Task.FromResult(Ok(""));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddMember()
        {
            return await Task.FromResult(Ok(""));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveMember()
        {
            return await Task.FromResult(Ok(""));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddList(AddListCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveList(RemoveListCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }
    }
}
