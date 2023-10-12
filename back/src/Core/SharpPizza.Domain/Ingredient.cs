using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    internal class Ingredient
    {
        [Column(TypeName = "INT")]
        public int Id { get; set; }

        [Column(TypeName = "NVARCHAR(20)")]
        public string Name { get; set; }

        [Column(TypeName = "BIT(True, False)")]
        public bool Available { get; set; }
    }
}
