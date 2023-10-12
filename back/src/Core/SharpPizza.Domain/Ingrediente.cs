using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    public class Ingrediente
    {

        public int Id { get; set; }


        public string? Name { get; set; }

        public List<PizzaIngrediente>? PizzaIngredientes { get; set; }
    }
}
