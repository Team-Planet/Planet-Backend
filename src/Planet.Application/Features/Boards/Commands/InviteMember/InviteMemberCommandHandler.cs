using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Planet.Application.Services.Authentication;
using Planet.Application.Services.Caching;
using Planet.Application.Services.Cryptography;
using Planet.Application.Services.Repositories;
using Planet.Domain.Boards;
using System.Numerics;
using System.Text;

namespace Planet.Application.Features.Boards.Commands.InviteMember
{
    public class InviteMemberCommandHandler : IRequestHandler<InviteMemberCommand, InviteMemberResponse>
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IUserService _userService;
        private readonly ICacheService _cacheService;
        private readonly ICryptographyService _cryptographyService;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InviteMemberCommandHandler(IBoardRepository boardRepository, IUserService userService, ICacheService cacheService, ICryptographyService cryptographyService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _boardRepository = boardRepository;
            _userService = userService;
            _cacheService = cacheService;
            _cryptographyService = cryptographyService;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<InviteMemberResponse> Handle(InviteMemberCommand request, CancellationToken cancellationToken)
        {
            var inviterId = _userService.GetUserId();
            var board = await _boardRepository.FindAsync(request.BoardId);
            bool canInvite = board.Members.FirstOrDefault(m => m.UserId == inviterId)?.Permissions.HasFlag(BoardPermissions.InviteMember) ?? false;

            if (!canInvite)
            {
                throw new Exception("Belirtilen pano için üye davet yetkiniz bulunmamaktadır.");
            }

            int expireInMinutes = int.Parse(_configuration["Invitation:ExpireInMinutes"]);
            string urlParameter = $"{request.BoardId}~{DateTime.Now.AddMinutes(expireInMinutes)}";
            byte[] encryptedUrlParameter = _cryptographyService.Encrypt(_configuration["Invitation:Key"], urlParameter);
            string invitationKey = Base64Url.Encode(encryptedUrlParameter);

            string host = _httpContextAccessor.HttpContext.Request.Host.Value;
            string scheme = _httpContextAccessor.HttpContext.Request.Scheme;

            string url = $"{scheme}://{host}/Boards/AcceptInvitation/{invitationKey}";

            return new InviteMemberResponse(url);
        }
    }
}
