using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpPizza.Application.Contracts.Identity;
using SharpPizza.Application.Features.Addresses.Commands.CreateAddress;
using SharpPizza.Application.Features.Addresses.Vms;
using SharpPizza.Application.Features.Orders.Commands.CreateOrder;
using SharpPizza.Application.Features.Orders.Commands.UpdateOrder;
using SharpPizza.Application.Features.Orders.Queries.GetOrdersById;
using SharpPizza.Application.Features.Orders.Queries.PaginationOrders;
using SharpPizza.Application.Features.Orders.Vms;
using SharpPizza.Application.Features.Shared.Queries;
using SharpPizza.Application.Models.Authorization;

namespace SharpPizza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IAuthService _authService;

        public OrderController(IMediator mediator, IAuthService authService)
        {
            _mediator = mediator;
            _authService = authService;
        }

        [HttpPost("address", Name = "CreateAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AddressVm>> CreateAddress([FromBody] CreateAddressCommand request)
        {
            return await _mediator.Send(request);
        }


        [HttpPost(Name = "CreateOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderVm>> CreateOrder([FromBody] CreateOrderCommand request)
        {
            return await _mediator.Send(request);
        }

        [Authorize(Roles = Role.ADMIN)]
        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderVm>> UpdateOrder([FromBody] UpdateOrderCommand request)
        {
            return await _mediator.Send(request);
        }


        [HttpGet("{id}", Name = "GetOrderById")]
        [ProducesResponseType( typeof(OrderVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderVm>> GetOrderById(int id)
        {
            var query = new GetOrdersByIdQuery(id);
            return Ok(await _mediator.Send(query));

        }


        [HttpGet("paginationByUsername", Name = "PaginationOrderByUsername")]
        [ProducesResponseType(typeof(PaginationVm<OrderVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<OrderVm>>> PaginationOrderByUsername
                                        (
                                            [FromQuery] PaginationOrdersQuery paginationOrdersParams
                                        )
        {
            
            paginationOrdersParams.Username = _authService.GetSessionUser();
            var  pagination = await _mediator.Send(paginationOrdersParams);
            return Ok(pagination);
        }
    

        
        [Authorize(Roles = Role.ADMIN)]
        [HttpGet("paginationAdmin", Name = "PaginationOrder")]
        [ProducesResponseType(typeof(PaginationVm<OrderVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<OrderVm>>> PaginationOrder
                                        (
                                            [FromQuery] PaginationOrdersQuery paginationOrdersParams
                                        )
        {
            var  pagination = await _mediator.Send(paginationOrdersParams);
            return Ok(pagination);
        }
    }
}