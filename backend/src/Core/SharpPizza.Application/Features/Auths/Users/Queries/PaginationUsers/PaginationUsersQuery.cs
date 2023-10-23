using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Shared.Queries;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Auths.Users.Queries.PaginationUsers
{
    public class PaginationUsersQuery : PaginationBaseQuery, IRequest<PaginationVm<Usuario>>
    {
        
    }
}