using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    public enum  ProductStatus
    {
        [EnumMember(Value = "Producto Inactivo")]
        Inactivo,
        [EnumMember(Value = "Producto Activo")]
        Activo
    }
}