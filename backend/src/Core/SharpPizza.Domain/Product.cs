using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain.Common;

namespace SharpPizza.Domain
{
    public class Product : BaseDomainModel
    {

    [Column(TypeName = "NVARCHAR(100)")]
    public string? Nombre { get; set; }

    [Column(TypeName = "INT")]
    public int Precio { get; set; }

    [Column(TypeName = "NVARCHAR(4000)")]
    public string? Descripcion { get; set; }

    public int Rating { get; set; }

    [Column(TypeName = "NVARCHAR(100)")]
    public string? Vendedor { get; set; }

    public int Stock {get;set;}

    public ProductStatus Status { get; set; } = ProductStatus.Activo;

    public int CategoryId { get; set; }
    public Category? Category {get;set;}

    public virtual ICollection<Review>? Reviews { get; set; }

    public virtual ICollection<Image>? Images { get; set; }
        
    }
}