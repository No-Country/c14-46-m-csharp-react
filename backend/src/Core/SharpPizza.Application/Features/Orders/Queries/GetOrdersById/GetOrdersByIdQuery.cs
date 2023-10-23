using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Orders.Vms;

namespace SharpPizza.Application.Features.Orders.Queries.GetOrdersById
{
    public class GetOrdersByIdQuery : IRequest<OrderVm>
    {
        public int OrderId { get; set; }

        public GetOrdersByIdQuery(int orderId)
        {
            this.OrderId = orderId ==0 ? throw new ArgumentNullException(nameof(orderId)) : orderId;
        }
    }
}