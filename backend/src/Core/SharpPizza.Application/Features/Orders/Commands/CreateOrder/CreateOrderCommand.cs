using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Orders.Vms;

namespace SharpPizza.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<OrderVm>
    {
        public Guid? ShoppingCartId {get;set;}
    }
}