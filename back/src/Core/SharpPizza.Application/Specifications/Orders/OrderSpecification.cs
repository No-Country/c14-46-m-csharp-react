using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain;

namespace SharpPizza.Application.Specifications.Orders
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification(OrderSpecificationParams orderParams)
           : base(
                   x =>
                    (
                        string.IsNullOrEmpty(orderParams.Username) || 
                            x.CompradorUsername!.Contains(orderParams.Username)) &&
                        (!orderParams.Id.HasValue || x.Id == orderParams.Id) 
                 )
        {
            AddInclude(p => p.OrderItems!);  

            ApplyPaging(orderParams.PageSize * (orderParams.PageIndex - 1), orderParams.PageSize);

             if (!string.IsNullOrEmpty(orderParams.Sort)){

                switch (orderParams.Sort)
                {
                    case "createDateAsc":
                        AddOrderBy(p => p.CreatedDate!);
                        break;

                    case "createDateDesc":
                        AddOrderByDescending(p => p.CreatedDate!);
                        break;
 
                    default:
                        AddOrderBy(p => p.CreatedDate!);
                        break;
                }
             }else{
                AddOrderByDescending(p => p.CreatedDate!);
             }

        }
    }
}