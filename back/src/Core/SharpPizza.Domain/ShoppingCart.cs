using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain.Common;

namespace SharpPizza.Domain
{
    public class ShoppingCart : BaseDomainModel
    {
        public Guid? ShoppingCartMasterId {get;set;}

        public virtual ICollection<ShoppingCartItem>? ShoppingCartItems {get;set;}    

    }
}