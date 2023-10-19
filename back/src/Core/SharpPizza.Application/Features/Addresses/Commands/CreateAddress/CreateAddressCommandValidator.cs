using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SharpPizza.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
         public CreateAddressCommandValidator()
        {
            RuleFor(p => p.Direccion)
                .NotEmpty().WithMessage("La direccion no puede ser nula");

            RuleFor(p => p.Ciudad)
                .NotEmpty().WithMessage("La ciudad no puede ser nula");

            RuleFor(p => p.Departamento)
                .NotEmpty().WithMessage("El Departamento no puede ser nulo");

            RuleFor(p => p.CodigoPostal)
                .NotEmpty().WithMessage("El Codigo Postal no puede ser nulo");

            RuleFor(p => p.Pais)
                .NotEmpty().WithMessage("El Pais no puede ser nulo");

        }
    }
}