using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Orders.Vms;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<OrderVm>
    {
        public int OrderId { get; set; }

        public OrderStatus Status {get;set;}
    }
}