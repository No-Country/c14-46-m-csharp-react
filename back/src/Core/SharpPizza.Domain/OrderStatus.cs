using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SharpPizza.Domain
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pendiente")]
        Pending,
        [EnumMember(Value = "El pago fue recibido")]
        Completed,
        [EnumMember(Value = "El producto fue enviado")]
        Enviado,
        [EnumMember(Value = "El pago tuvo errores")]
        Error
    }
}