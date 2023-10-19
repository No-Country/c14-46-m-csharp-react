using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharpPizza.Application.Features.Countries.Vms;
using SharpPizza.Application.Persistence;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Countries.Queries.GetCountryList
{
    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, IReadOnlyList<CountryVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCountryListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<CountryVm>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
    
            var countries = await _unitOfWork.Repository<Country>().GetAsync(
                null,
                x => x.OrderBy(y => y.Name),
                string.Empty,
                false
            );

            
            return _mapper.Map<IReadOnlyList<CountryVm>>(countries);

        }
    }
}