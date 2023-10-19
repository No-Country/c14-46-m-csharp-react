using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain.Common;

namespace SharpPizza.Domain
{
    public class Category : BaseDomainModel
    {
        [Column(TypeName = "NVARCHAR(100)")]
        public string? Nombre { get; set; }
        
        public virtual ICollection<Product>? Products {get;set;}       
    }
}