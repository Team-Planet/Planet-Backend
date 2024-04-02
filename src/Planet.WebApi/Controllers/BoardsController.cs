using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return await Task.FromResult(Ok(""));
        }

        [HttpPost]
        public async Task<IActionResult> Edit()
        {
            return await Task.FromResult(Ok(""));
        }

        [HttpPost]
        public async Task<IActionResult> AddMember()
        {
            return await Task.FromResult(Ok(""));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveMember()
        {
            return await Task.FromResult(Ok(""));
        }

        [HttpPost]
        public async Task<IActionResult> AddList()
        {
            return await Task.FromResult(Ok(""));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveList()
        {
            return await Task.FromResult(Ok(""));
        }
    }
}
