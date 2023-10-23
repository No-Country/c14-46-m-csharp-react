using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpPizza.Application.Features.ShoppingCarts.Commands.DeleteShoppingCartItem;
using SharpPizza.Application.Features.ShoppingCarts.Commands.UpdateShoppingCart;
using SharpPizza.Application.Features.ShoppingCarts.Queries.GetShoppingCartById;
using SharpPizza.Application.Features.ShoppingCarts.Vms;

namespace SharpPizza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private IMediator _mediator;

        public ShoppingCartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetShoppingCart")]
        [ProducesResponseType(typeof(ShoppingCartVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartVm>> GetShoppingCart(Guid id)
        {
        var shoppingCartId = id == Guid.Empty ? Guid.NewGuid() :  id;
        var query = new GetShoppingCartByIdQuery(shoppingCartId);
        return await _mediator.Send(query);
            
        }

        [AllowAnonymous]
        [HttpPut("{id}", Name = "UpdateShoppingCart")]
        [ProducesResponseType(typeof(ShoppingCartVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartVm>> UpdateShoppingCart(Guid id, UpdateShoppingCartCommand request)
        {
            request.ShoppingCartId = id;
            return await _mediator.Send(request);
            
        }

        [AllowAnonymous]
        [HttpDelete("item/{id}", Name = "DeleteShoppingCart")]
        [ProducesResponseType(typeof(ShoppingCartVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartVm>> DeleteShoppingCart(int id)
        {
            return await _mediator.Send(new DeleteShoppingCartItemCommand() { Id = id});
        }
    }
}