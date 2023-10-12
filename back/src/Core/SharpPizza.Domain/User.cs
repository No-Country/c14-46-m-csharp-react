using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string? UserName { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Rol { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? ImageUrl {  get; set; }



    }
}
