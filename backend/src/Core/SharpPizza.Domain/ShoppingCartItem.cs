using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain.Common;

namespace SharpPizza.Domain
{
    public class ShoppingCartItem : BaseDomainModel
    {
        public string? Producto { get; set; }

        [Column(TypeName ="INT")]
        public int Precio {get;set;}

        public int Cantidad { get; set; }

        public string?  Imagen { get; set; }

        public string?  Categoria { get; set; }

        public Guid? ShoppingCartMasterId {get;set;}

        public int ShoppingCartId {get;set;}
        public virtual ShoppingCart? ShoppingCart {get;set;}

        public int ProductId {get;set;}

        public int Stock {get;set;}

    }
}