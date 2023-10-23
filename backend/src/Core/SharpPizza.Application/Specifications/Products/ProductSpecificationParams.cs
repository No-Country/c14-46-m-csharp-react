using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain;

namespace SharpPizza.Application.Specifications.Products
{
    public class ProductSpecificationParams : SpecificationParams
    {
        public int? CategoryId { get; set; }

        public int?  PrecioMax { get; set; }

        public int? PrecioMin { get; set; }

        public int? Rating { get; set; }

        public ProductStatus? Status {get;set;}
    }
}