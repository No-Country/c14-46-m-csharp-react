using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpPizza.Domain.Common;

namespace SharpPizza.Domain
{
    public class Country : BaseDomainModel
    {
        public string? Name { get; set; }

        public string? Iso2 {get;set;}

        public string? Iso3 {get;set;}       

    }
}