using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharpPizza.Application.Specifications;

namespace SharpPizza.Infrastructure.Specification
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            if(spec.Criteria != null)
            {
                inputQuery = inputQuery.Where(spec.Criteria);
            }

            if(spec.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDescending != null)
            {
                inputQuery = inputQuery.OrderBy(spec.OrderByDescending);
            }

            if(spec.IsPagingEnable)
            {
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
            }

            inputQuery = spec.Includes!.Aggregate(inputQuery, 
                            (current, include) => current.Include(include)).AsSplitQuery().AsNoTracking();

            return inputQuery;
        }
        
    }
}