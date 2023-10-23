using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Reviews.Queries.Vms;
using SharpPizza.Application.Features.Shared.Queries;

namespace SharpPizza.Application.Features.Reviews.Queries.PaginationReviews
{
    public class PaginationReviewsQuery : PaginationBaseQuery, IRequest<PaginationVm<ReviewVm>>
    {
        public int?  ProductId { get; set; }
    }
}