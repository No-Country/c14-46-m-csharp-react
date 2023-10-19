using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Auths.Users.Vms;

namespace SharpPizza.Application.Features.Auths.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<AuthResponse>
    {
        public string? UserId { get; set; }

        public GetUserByIdQuery(string userId)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        }
    }
}