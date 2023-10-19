using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpPizza.Application.Specifications.Reviews
{
    public class ReviewSpecificationParams : SpecificationParams
    {
        public int? ProductId {get;set;}
    }
}