using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpPizza.Application.Features.ShoppingCarts.Vms
{
    public class ShoppingCartVm
    {
        public string? ShoppingCartId {get;set;}

        public List<ShoppingCartItemVm>? ShoppingCartItems {get;set;}

        public decimal Total {
            get {
                return

                        (
                            ShoppingCartItems!.Sum(x => x.Precio * x.Cantidad) +
                            (ShoppingCartItems!.Sum(x => x.Precio * x.Cantidad)) +
                            ((ShoppingCartItems!.Sum(x => x.Precio * x.Cantidad)) < 100 ? 10 : 25)
                        );

            }


            set {}

        }


        public int Cantidad 
        {
            get {  return ShoppingCartItems!.Sum(x => x.Cantidad); }
            set {}
        }

        public int SubTotal
        {
            get { return ( ShoppingCartItems!.Sum(x => x.Precio * x.Cantidad)); }
        }

        public int Impuesto
        {
            get { 
                return ((ShoppingCartItems!.Sum(x => x.Precio * x.Cantidad))); 
                }
            set{}
        }   

        public int PrecioEnvio
        {
            get{
                return (ShoppingCartItems!.Sum(x => x.Precio *  x.Cantidad)) < 100 ? 10 : 25;
            }

            set{}
        }   
    }
}