using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain;

namespace SharpPizza.Application.Specifications.Users
{
    public class UserSpecification : BaseSpecification<Usuario>
    {
        public UserSpecification(UserSpecificationParams userParams) : base(
            x => 
            (string.IsNullOrEmpty(userParams.Search) || x.Nombre!.Contains(userParams.Search) 
            || x.Apellido!.Contains(userParams.Search) || x.Email!.Contains(userParams.Search)
            )
        )
        {
            ApplyPaging(userParams.PageSize * (userParams.PageIndex - 1), userParams.PageSize);

            if(!string.IsNullOrEmpty(userParams.Sort))
            {
                switch(userParams.Sort)
                {
                    case "nombreAsc":
                            AddOrderBy(p => p.Nombre!);
                            break;
                    
                    case "nombreDesc":
                            AddOrderByDescending(p => p.Nombre!);
                            break;

                    case "apellidoAsc":
                            AddOrderBy(p => p.Apellido!);
                            break;
                    
                    case "apellidoDesc":
                            AddOrderByDescending(p => p.Apellido!);
                            break;
                    
                    default:
                            AddOrderBy(p => p.Nombre!);
                            break;


                }
            }
            else {
                AddOrderByDescending(p => p.Nombre!);
            }       
        }
    }
}