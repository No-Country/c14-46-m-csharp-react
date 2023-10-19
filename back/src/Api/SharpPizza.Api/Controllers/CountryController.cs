using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpPizza.Application.Features.Countries.Queries.GetCountryList;
using SharpPizza.Application.Features.Countries.Vms;

namespace SharpPizza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetCountries")]
        [ProducesResponseType(typeof(IReadOnlyList<CountryVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<CountryVm>>> GetCountries()
        {
            var query = new GetCountryListQuery();
            return Ok(await _mediator.Send(query));
        }
    }
}