using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    public class PizzaIngrediente
    {
        public int PizzaId { get; set; }
        public Pizza? Pizza { get; set; }


        public int IngredienteId { get; set; }
        public Ingrediente? Ingrediente { get; set; }

        
        
    }
}
