using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharpPizza.Application.Exceptions;
using SharpPizza.Application.Features.Products.Queries.Vms;
using SharpPizza.Application.Persistence;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _unitOfWork.Repository<Product>().GetByIdAsync(request.ProductId);
            if(productToUpdate is null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            productToUpdate.Status = productToUpdate.Status == ProductStatus.Inactivo 
                            ? ProductStatus.Activo : ProductStatus.Inactivo;

                
            await _unitOfWork.Repository<Product>().UpdateAsync(productToUpdate);

            return _mapper.Map<ProductVm>(productToUpdate);
        }
    }
}