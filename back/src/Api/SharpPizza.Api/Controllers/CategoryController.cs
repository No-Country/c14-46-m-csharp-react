using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpPizza.Application.Features.Categories.Queries.GetCategoryList;
using SharpPizza.Application.Features.Categories.Vms;

namespace SharpPizza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("list" ,Name = "GetCategoryList")]
        [ProducesResponseType(typeof(IReadOnlyList<CategoryVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<CategoryVm>>> GetCategoryList()
        {
            var query = new GetCategoryListQuery();
            return Ok(await _mediator.Send(query));
        }
    }
}