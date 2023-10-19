using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Orders.Vms;
using SharpPizza.Application.Features.Shared.Queries;

namespace SharpPizza.Application.Features.Orders.Queries.PaginationOrders
{
    public class PaginationOrdersQuery : PaginationBaseQuery, IRequest<PaginationVm<OrderVm>>
    {
        public int? Id { get; set; }
        public string? Username { get; set; }
    }
}