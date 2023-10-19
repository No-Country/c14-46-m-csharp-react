using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharpPizza.Application.Features.Reviews.Queries.Vms;
using SharpPizza.Application.Features.Shared.Queries;
using SharpPizza.Application.Persistence;
using SharpPizza.Application.Specifications.Reviews;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Reviews.Queries.PaginationReviews
{
    public class PaginationReviewsQueryHandler : IRequestHandler<PaginationReviewsQuery, PaginationVm<ReviewVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaginationReviewsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginationVm<ReviewVm>> Handle(PaginationReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviewSpecificationParams = new ReviewSpecificationParams
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Search = request.Search,
                Sort  = request.Sort,
                ProductId = request.ProductId
            };

            var spec = new ReviewSpecification(reviewSpecificationParams);
            var reviews = await _unitOfWork.Repository<Review>().GetAllWithSpec(spec);

            var specCount = new ReviewForCountingSpecification(reviewSpecificationParams);
            var totalReviews = await _unitOfWork.Repository<Review>().CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalReviews) / Convert.ToDecimal(request.PageSize));
            var totalPages = Convert.ToInt32(rounded);

            var data  = _mapper.Map<IReadOnlyList<Review>, IReadOnlyList<ReviewVm>>(reviews);

            var reviewsByPage = reviews.Count();

            var pagination = new PaginationVm<ReviewVm>
            {
                Count = totalReviews,
                Data = data,
                PageCount = totalPages,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                ResultByPage = reviewsByPage
            };

            return  pagination;
        }
    }
}