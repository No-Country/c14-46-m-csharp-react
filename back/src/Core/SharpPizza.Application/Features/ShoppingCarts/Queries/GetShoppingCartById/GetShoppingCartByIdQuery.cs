using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.ShoppingCarts.Vms;

namespace SharpPizza.Application.Features.ShoppingCarts.Queries.GetShoppingCartById
{
    public class GetShoppingCartByIdQuery : IRequest<ShoppingCartVm>
    {
        public Guid? ShoppingCartId {get;set;}

        public GetShoppingCartByIdQuery(Guid? shoppingCartId)
        {
            ShoppingCartId = shoppingCartId ?? throw new ArgumentNullException(nameof(shoppingCartId));
        }
    }
}