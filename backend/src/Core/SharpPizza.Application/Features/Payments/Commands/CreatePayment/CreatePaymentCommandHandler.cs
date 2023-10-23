using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharpPizza.Application.Features.Orders.Vms;
using SharpPizza.Application.Persistence;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, OrderVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderVm> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var orderToPay = await _unitOfWork.Repository<Order>().GetEntityAsync(
                x => x.Id == request.OrderId,
                null,
                false
            );

            orderToPay.Status = OrderStatus.Completed;
            _unitOfWork.Repository<Order>().UpdateEntity(orderToPay);

            var ShoppingCartItems = await _unitOfWork.Repository<ShoppingCartItem>().GetAsync(
                x => x.ShoppingCartMasterId == request.ShoppingCartMasterId
            );

            _unitOfWork.Repository<ShoppingCartItem>().DeleteRange(ShoppingCartItems);

            await _unitOfWork.Complete();


            return _mapper.Map<OrderVm>(orderToPay);
        }
    }
}