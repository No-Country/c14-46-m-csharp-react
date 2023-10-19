using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Application.Features.Addresses.Vms;

namespace SharpPizza.Application.Features.Auths.Users.Vms
{
    public class AuthResponse
    {
        public string? Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string?  Telefono { get; set; }

        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Token {get;set;}

        public string? Avatar { get; set; }

        public AddressVm? DireccionEnvio { get; set; }

        public ICollection<string>? Roles {get;set;}
    }
}