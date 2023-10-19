using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Orders.Vms;

namespace SharpPizza.Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<OrderVm>
    {
        public int OrderId {get;set;}

        public Guid? ShoppingCartMasterId {get;set;}   
    }
}