using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Categories.Vms;

namespace SharpPizza.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<IReadOnlyList<CategoryVm>>
    {
        
    }
}