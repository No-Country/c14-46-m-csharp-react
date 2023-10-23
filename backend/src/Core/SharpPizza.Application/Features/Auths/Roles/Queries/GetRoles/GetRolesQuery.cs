using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SharpPizza.Application.Features.Auths.Roles.Queries.GetRoles
{
    public class GetRolesQuery : IRequest<List<string>>
    {
        
    }
}