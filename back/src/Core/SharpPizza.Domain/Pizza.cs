using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la pizza es requerido... ")]
        [Column(TypeName = "NVARCHAR(100)")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "El precio de la pizza es requerido ")]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal UnitPirce { get; set; }


        [Required(ErrorMessage = "El nombre de la pizza es requerido... ")]
        [Column(TypeName = "NVARCHAR(4000)")]
        public string? ImageUrl { get; set; }

        public bool SoldOut { get; set; } = false;
        public List<PizzaIngrediente>? PizzaIngredientes { get; set; }
    }
}
