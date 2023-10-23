using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.ShoppingCarts.Vms;

namespace SharpPizza.Application.Features.ShoppingCarts.Commands.UpdateShoppingCart
{
    public class UpdateShoppingCartCommand : IRequest<ShoppingCartVm>
    {
        public Guid? ShoppingCartId {get;set;}

        public List<ShoppingCartItemVm>? ShoppingCartItems {get;set;}
    }
}