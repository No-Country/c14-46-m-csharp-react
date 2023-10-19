using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpPizza.Application.Specifications.Orders
{
    public class OrderSpecificationParams : SpecificationParams
    {
        public string? Username { get; set; }
        public int? Id { get; set; } 
    }
}