using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpPizza.Application.Features.Reviews.Commands.CreateReview;
using SharpPizza.Application.Features.Reviews.Commands.DeleteReview;
using SharpPizza.Application.Features.Reviews.Queries.PaginationReviews;
using SharpPizza.Application.Features.Reviews.Queries.Vms;
using SharpPizza.Application.Features.Shared.Queries;
using SharpPizza.Application.Models.Authorization;

namespace SharpPizza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateReview")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ReviewVm>> CreateReview([FromBody] CreateReviewCommand request)
        {
            return await _mediator.Send(request);
        }


        [Authorize(Roles = Role.ADMIN)]
        [HttpDelete("{id}", Name = "DeleteReview")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> DeleteReview(int id)
        {
            var request = new DeleteReviewCommand(id);
            return await _mediator.Send(request);
        }


        [Authorize(Roles = Role.ADMIN)]
        [HttpGet("paginationReviews", Name = "PaginationReview")]
        [ProducesResponseType(typeof(PaginationVm<ReviewVm>),  (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> PaginationReview([FromQuery] PaginationReviewsQuery request)
        {
            var paginationReview = await _mediator.Send(request);
            return Ok(paginationReview);
        }
    }
}