using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Countries.Vms;

namespace SharpPizza.Application.Features.Countries.Queries.GetCountryList
{
    public class GetCountryListQuery : IRequest<IReadOnlyList<CountryVm>>
    {
        
    }
}