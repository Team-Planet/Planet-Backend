using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Users.ChangePassword
{
    public record ChangePasswordCommand(string Email, string OldPassword, string NewPassword) : IRequest<ChangePasswordResponse>;

}
