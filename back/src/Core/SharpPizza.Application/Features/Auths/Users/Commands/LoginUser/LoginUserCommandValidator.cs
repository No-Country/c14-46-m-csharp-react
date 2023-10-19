using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SharpPizza.Application.Features.Auths.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El Email no puede ser nulo");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("El Password no puede ser nulo");
        }
    }
}