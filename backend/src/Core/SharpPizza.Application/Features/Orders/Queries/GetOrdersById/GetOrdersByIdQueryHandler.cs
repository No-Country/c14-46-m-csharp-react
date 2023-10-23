using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharpPizza.Application.Features.Orders.Vms;
using SharpPizza.Application.Persistence;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Orders.Queries.GetOrdersById
{
    public class GetOrdersByIdQueryHandler : IRequestHandler<GetOrdersByIdQuery, OrderVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrdersByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderVm> Handle(GetOrdersByIdQuery request, CancellationToken cancellationToken)
        {
            var includes = new List<Expression<Func<Order, object>>>();
            includes.Add(p =>p.OrderItems!.OrderBy(x => x.Product));
            includes.Add(p => p.OrderAddress!);

            var order = await _unitOfWork.Repository<Order>().GetEntityAsync(
                x => x.Id == request.OrderId,
                includes,
                false
            );

            return _mapper.Map<OrderVm>(order);

        } 
    }
}