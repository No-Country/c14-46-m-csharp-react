using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Products.Queries.Vms;

namespace SharpPizza.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<IReadOnlyList<ProductVm>>
    {
        
    }
}