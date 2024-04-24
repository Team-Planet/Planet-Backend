using MediatR;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Features.Cards.Commands.AddLabel;
using Planet.Application.Features.Cards.Commands.CreateCard;
using Planet.Application.Features.Cards.Commands.EditDate;
using Planet.Application.Features.Cards.Commands.EditDescription;
using System.ComponentModel;
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
    }
}
