using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Auths.Users.Vms;

namespace SharpPizza.Application.Features.Auths.Users.Queries.GetUserByToken
{
    public class GetUserByTokenQuery : IRequest<AuthResponse>
    {
        
    }
}