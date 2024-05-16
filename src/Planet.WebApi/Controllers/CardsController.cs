using MediatR;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Features.Cards.Commands.AddCardCheckList;
using Planet.Application.Features.Cards.Commands.AddCardComment;
using Planet.Application.Features.Cards.Commands.AddLabel;
using Planet.Application.Features.Cards.Commands.AssignUser;
using Planet.Application.Features.Cards.Commands.CreateCard;
using Planet.Application.Features.Cards.Commands.EditCardDescription;
using Planet.Application.Features.Cards.Commands.EditDate;
using Planet.Application.Features.Cards.Commands.EditDescription;
using Planet.Application.Features.Cards.Queries.GetCardInfo;
using Planet.Application.Features.Cards.Queries.GetListCards;

namespace Planet.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateCardCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EditDescriptiion(EditCardDescriptionCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddLabelToCard(AddLabelCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> EditCardDate(EditDateCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCardComment(AddCardCommentCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCardCheckList(AddCardCheckListCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCardInfo([FromQuery] GetCardInfoQuery query, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(query, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AssignUser(AssignUserCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListCards([FromQuery] GetListCardsQuery query, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(query, cancellationToken);

            return Ok(response);
        }
    }
}
