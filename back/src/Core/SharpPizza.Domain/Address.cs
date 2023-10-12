using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    internal class Address
    {
        [Column(TypeName = "INT")]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string UserAddress { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string Department { get; set; }

        [Column(TypeName = "NVARCHAR(20)")]
        public string City { get; set; }

        [Column(TypeName = "NVARCHAR(20)")]
        public string UserName { get; set; }
    }
}
