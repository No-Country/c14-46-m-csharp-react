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

namespace SharpPizza.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
        var productToUpdate = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id);
        if(productToUpdate is null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));
            await _unitOfWork.Repository<Product>().UpdateAsync(productToUpdate);

            if(   (request.ImageUrls is not null)  && request.ImageUrls.Count > 0 )
            {
                var imagesToRemove = await _unitOfWork.Repository<Image>().GetAsync(
                    x => x.ProductId == request.Id
                );

                _unitOfWork.Repository<Image>().DeleteRange(imagesToRemove);

                request.ImageUrls.Select(c => {c.ProductId = request.Id; return c;}).ToList();
                var images = _mapper.Map<List<Image>>(request.ImageUrls);
                _unitOfWork.Repository<Image>().AddRange(images);

                await _unitOfWork.Complete();
            }

            
            return _mapper.Map<ProductVm>(productToUpdate);

        }
    }
}