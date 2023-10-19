using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SharpPizza.Application.Features.Addresses.Vms;

namespace SharpPizza.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<AddressVm>
    {
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }

        public string? Departamento { get; set; }
        public string? CodigoPostal { get; set; }

        public string? Pais { get; set; }
    }
}