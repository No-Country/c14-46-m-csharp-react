using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    internal class Ingredient
    {
        private int _id;
        private string _name;
        private bool _available;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public bool Available { get => _available; set => _available = value; }
    }
}
