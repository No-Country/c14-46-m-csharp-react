using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpPizza.Application.Features.ShoppingCarts.Vms
{
    public class ShoppingCartItemVm
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string? Producto {get;set;}
        public int Precio {get;set;}
        public int Cantidad { get; set; }

        public string? Categoria { get; set; }
        public int Stock {get;set;}

        public int TotalLine 
        {
            get 
            {
                return (Cantidad * Precio);
            }


            set {}
        }   
    }
}