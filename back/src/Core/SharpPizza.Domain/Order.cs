using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    internal class Order
    {
        [Column(TypeName = "INT")]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(30)")]
        public string BuyerUserName { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string OrderAddress { get; set;}

        [Column(TypeName = "NVARCHAR(50)")]
        public string OrderItems { get; set;}

        [Column(TypeName = "Decimal")]
        public float SubTotal { get; set;}

        [Column(TypeName = "NVARCHAR(50)")]
        public String OrderStatus { get; set;}

        [Column(TypeName = "Decimal")]
        public float Total { get; set; }
    }
}
