using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain.Common;

namespace SharpPizza.Domain
{
    public class Order : BaseDomainModel
    {
        public Order()
        {
            
        }
        public Order(
            string compradorNombre,
            string compradorEmail,
            OrderAddress orderAddress,
            int subtotal,
            int total,
            int impuesto,
            int precioEnvio
        ){
            CompradorNombre = compradorNombre;
            CompradorUsername = compradorEmail;
            OrderAddress = orderAddress;
            Subtotal = subtotal;
            Total = total;
            Impuesto = impuesto;
            PrecioEnvio = precioEnvio;
        }

        public string? CompradorNombre { get; set; }

        public string? CompradorUsername {get;set;}

        public OrderAddress? OrderAddress { get; set; }

        public IReadOnlyList<OrderItem>? OrderItems {get;set;}

        [Column(TypeName ="INT")]
        public int Subtotal { get; set; }

        public OrderStatus Status {get;set;} = OrderStatus.Pending;

        [Column(TypeName ="INT")]
        public int Total {get;set;}

        [Column(TypeName ="INT")]
        public int Impuesto {get;set;}

        [Column(TypeName ="INT")]
        public int PrecioEnvio {get;set;}
    
        public string? PaymentIntentId {get;set;}

        public string? ClientSecret {get;set;}

        public string? StripeApiKey {get;set;}       
    }
}