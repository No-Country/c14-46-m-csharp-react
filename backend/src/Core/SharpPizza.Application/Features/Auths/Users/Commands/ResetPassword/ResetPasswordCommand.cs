using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SharpPizza.Application.Features.Auths.Users.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest
    {
        public string? NewPassword { get; set; }

        public string? OldPassword { get; set; }
    }
}