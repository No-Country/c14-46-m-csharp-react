using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharpPizza.Application.Exceptions;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Auths.Users.Commands.ResetPasswordByToken
{
    public class ResetPasswordByTokenCommandHandler : IRequestHandler<ResetPasswordByTokenCommand, string>
    {
        private readonly UserManager<Usuario> _userManager;

        public ResetPasswordByTokenCommandHandler(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> Handle(ResetPasswordByTokenCommand request, CancellationToken cancellationToken)
        {

            if(!string.Equals(request.Password, request.ConfirmPassword))
            {
                throw new BadRequestException("El password no es igual a la confirmacion del password");
            }

            var updateUsuario = await _userManager.FindByEmailAsync(request.Email!);
            if(updateUsuario is null)
            {
                throw new BadRequestException("El email no esta registrado como usuario");
            }

            var token = Convert.FromBase64String(request.Token!);
            var tokenResult = Encoding.UTF8.GetString(token);

            var resetResultado = await  _userManager.ResetPasswordAsync(updateUsuario, tokenResult, request.Password!);
            if(!resetResultado.Succeeded)
            {
                throw new Exception("No se pudo resetear el password");
            }


            return $"Se actualizo exitosamente tu password ${request.Email}";
    
        }
    }
}