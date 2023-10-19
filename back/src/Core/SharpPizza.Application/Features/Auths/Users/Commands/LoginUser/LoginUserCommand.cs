using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Auths.Users.Vms;

namespace SharpPizza.Application.Features.Auths.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AuthResponse>
    {
        public string? Email{ get; set; }

        public string? Password{ get; set; }
    }
}