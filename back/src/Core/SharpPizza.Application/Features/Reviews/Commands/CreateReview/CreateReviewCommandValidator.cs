using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SharpPizza.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {

            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("Nombre no permite valores nulos");

            RuleFor(p => p.Comentario)
                .NotNull().WithMessage("Comentario no permite valores nulos");

            RuleFor(p => p.Rating)
            .NotEmpty().WithMessage("Rating no permite valores nulos");


        }
    }
}