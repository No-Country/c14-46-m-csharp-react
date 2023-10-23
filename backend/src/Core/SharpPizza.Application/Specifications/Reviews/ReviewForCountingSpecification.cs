using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain;

namespace SharpPizza.Application.Specifications.Reviews
{
    public class ReviewForCountingSpecification : BaseSpecification<Review>
    {
        public ReviewForCountingSpecification(ReviewSpecificationParams reviewParams)
            : base(
                x => 
                (!reviewParams.ProductId.HasValue || x.ProductId == reviewParams.ProductId)
            )
        {
        }
    }
}