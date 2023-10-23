using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SharpPizza.Application.Features.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest
    {
        public int ReviewId { get; set; }

        public DeleteReviewCommand(int reviewId)
        {
            ReviewId = reviewId == 0 ? throw new ArgumentNullException(nameof(reviewId)) : reviewId;
        }
    }
}