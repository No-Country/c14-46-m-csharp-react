using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain.Common;

namespace SharpPizza.Domain
{
    public class OrderItem : BaseDomainModel
    {
        public Product? Product {get;set;}

        public int ProductId {get;set;}
    
        [Column(TypeName = "INT")]
        public int Precio { get; set; }
        
        public int Cantidad { get; set; }

        public Order? Order {get;set;}   

        public int OrderId {get;set;}   

        public int ProductItemId {get;set;}   

        public string? ProductNombre {get;set;}   

        public string? ImagenUrl {get;set;}   
    }
}