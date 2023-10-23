using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.ShoppingCarts.Vms;

namespace SharpPizza.Application.Features.ShoppingCarts.Commands.DeleteShoppingCartItem
{
    public class DeleteShoppingCartItemCommand : IRequest<ShoppingCartVm>
    {
        public int Id { get; set; }
    }
}