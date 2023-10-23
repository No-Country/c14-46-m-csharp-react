using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Auths.Users.Vms;

namespace SharpPizza.Application.Features.Auths.Users.Queries.GetUserByUsername
{
    public class GetUserByUsernameQuery : IRequest<AuthResponse>
    {
        public string? Username  { get; set; } 

        public GetUserByUsernameQuery(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(Username));
        }
    }
}