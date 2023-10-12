using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    public class Jwt
    {
        public string? Key { get; set; }
    
        public string? Issuer { get; set; }

        public string? Audience { get; set; }

        public string? Subject { get; set; }

    }
}
