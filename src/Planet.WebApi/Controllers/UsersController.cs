using Microsoft.AspNetCore.Mvc;
using Planet.Application.Services.Cryptography;

namespace Planet.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICryptographyService _cryptographyService;

        public UsersController(ICryptographyService cryptographyService)
        {
            _cryptographyService = cryptographyService;
        }

    }
}
