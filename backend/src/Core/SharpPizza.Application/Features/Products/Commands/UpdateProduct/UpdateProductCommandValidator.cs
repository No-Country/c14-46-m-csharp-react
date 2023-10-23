using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SharpPizza.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            
            RuleFor(p => p.Nombre)
                    .NotEmpty().WithMessage("El Nombre no puede estar en blanco")
                    .MaximumLength(50).WithMessage("El Nombre no puede exceder los 50 caracteres");

                RuleFor(p => p.Descripcion)
                    .NotEmpty().WithMessage("La Descripcion no puede ser nula");

                RuleFor(p => p.Stock)
                    .NotEmpty().WithMessage("El Stock no puede ser nulo");

                RuleFor(p => p.Precio)
                    .NotEmpty().WithMessage("El Precio no puede ser nulo");

        }
    }
}