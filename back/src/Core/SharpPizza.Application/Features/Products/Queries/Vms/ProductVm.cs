using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Application.Features.Images.Queries;
using SharpPizza.Application.Features.Reviews.Queries.Vms;
using SharpPizza.Application.Models.Product;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Products.Queries.Vms
{
    public class ProductVm
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public decimal Precio {get;set;}

        public int Rating { get; set; }

        public string? Vendedor { get; set; }

        public int Stock { get; set; }

        public virtual ICollection<ReviewVm>? Reviews {get;set;}

        public virtual ICollection<ImageVm>? Images {get;set;}

        public int CategoryId { get; set; }       

        public string? CategoryNombre {get;set;}

        public int NumeroReviews { get; set; }

        public ProductStatus Status {get;set;}   

        public string StatusLabel {
            get {
                switch(Status)
                {
                    case ProductStatus.Activo: {
                        return ProductoStatusLabel.ACTIVO;
                    }

                    case ProductStatus.Inactivo: {
                        return ProductoStatusLabel.INACTIVO;
                    }
                    
                    default: return ProductoStatusLabel.INACTIVO;
                }
            }
            set {}
        }
    }
}