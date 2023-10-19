using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharpPizza.Application.Features.Products.Queries.Vms;
using SharpPizza.Application.Features.Shared.Queries;
using SharpPizza.Application.Persistence;
using SharpPizza.Application.Specifications.Products;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Products.Queries.PaginationProducts
{
    public class PaginationProductsQueryHandler : IRequestHandler<PaginationProductsQuery, PaginationVm<ProductVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaginationProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginationVm<ProductVm>> Handle(PaginationProductsQuery request, CancellationToken cancellationToken)
        {
            
            var productSpecificationParams = new ProductSpecificationParams
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Search = request.Search,
                Sort = request.Sort,
                CategoryId = request.CategoryId,
                PrecioMax = request.PrecioMax,
                PrecioMin = request.PrecioMin,
                Rating = request.Rating,
                Status = request.Status
            };

            var spec = new ProductSpecification(productSpecificationParams);
            var products = await _unitOfWork.Repository<Product>().GetAllWithSpec(spec);

            var specCount = new ProductForCountingSpecification(productSpecificationParams);
            var totalProducts = await _unitOfWork.Repository<Product>().CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProducts) / Convert.ToDecimal(request.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data = _mapper.Map<IReadOnlyList<ProductVm>>(products);
            var productsByPage = products.Count();

            var pagination = new PaginationVm<ProductVm>
            {
                Count = totalProducts,
                Data = data,
                PageCount = totalPages,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                ResultByPage = productsByPage
            };

            return pagination;
        }
    }
}