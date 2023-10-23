using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Products.Queries.Vms;
using SharpPizza.Application.Features.Shared.Queries;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Products.Queries.PaginationProducts
{
    public class PaginationProductsQuery : PaginationBaseQuery, IRequest<PaginationVm<ProductVm>>
    {
        public int? CategoryId { get; set; }

        public int?  PrecioMax { get; set; }

        public int?  PrecioMin { get; set; }

        public int? Rating {get;set;}

        public ProductStatus? Status {get;set;}
        
    }
}