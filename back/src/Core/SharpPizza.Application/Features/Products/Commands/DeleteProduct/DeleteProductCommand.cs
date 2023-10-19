using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Products.Queries.Vms;

namespace SharpPizza.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ProductVm>
    {
        public int ProductId { get; set; }

        public DeleteProductCommand(int productId)
        {
            ProductId = productId == 0 ? throw new ArgumentException(nameof(productId)) : productId;
        }
    }
}