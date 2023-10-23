using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpPizza.Application.Features.Orders.Vms
{
    public class OrderItemVm
    {
        public int ProductId { get; set; }

        public int Precio { get; set; }

        public int Cantidad { get; set; }

        public int OrderId {get;set;}

        public int ProductItemId { get; set; }

        public string? ProductNombre{ get; set; }

        public string? ImagenUrl {get;set;} 
    }
}