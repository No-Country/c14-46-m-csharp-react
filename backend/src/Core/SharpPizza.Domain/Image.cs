using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain.Common;

namespace SharpPizza.Domain
{
    public class Image : BaseDomainModel
    {
        [Column(TypeName = "NVARCHAR(4000)")]
        public string? Url {get;set;}

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        // codigo id del proveedor de imagenes
        public string? PublicCode { get; set; }        
        
    }
}