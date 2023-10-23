using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharpPizza.Application.Features.Orders.Vms;
using SharpPizza.Application.Features.Payments.Commands.CreatePayment;

namespace SharpPizza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreatePayment")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderVm>>  CreatePayment(
                [FromBody]  CreatePaymentCommand request
        )
        {
            return await _mediator.Send(request);
        }
    }
}