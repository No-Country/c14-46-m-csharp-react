using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharpPizza.Application.Features.Products.Queries.Vms;
using SharpPizza.Application.Persistence;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductVm>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request);
            await _unitOfWork.Repository<Product>().AddAsync(productEntity);

            if( (request.ImageUrls is not null) && request.ImageUrls.Count > 0 )
            {
                request.ImageUrls.Select(c => {c.ProductId = productEntity.Id; return c;}).ToList();

                var images = _mapper.Map<List<Image>>(request.ImageUrls);
                _unitOfWork.Repository<Image>().AddRange(images);
                await _unitOfWork.Complete();
            }

            return _mapper.Map<ProductVm>(productEntity);
        }
    }
}