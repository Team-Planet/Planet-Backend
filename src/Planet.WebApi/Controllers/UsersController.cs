using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planet.Application.Features.Users.CreateUser;
using Planet.Application.Features.Users.SignIn;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.SharedKernel;
using Planet.Infrastructure.Services.Cryptography;
using System.Security.Claims;

namespace Planet.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(response);
        }


    }
}
