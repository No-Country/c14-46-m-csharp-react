using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharpPizza.Application.Exceptions;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Auths.Users.Commands.UpdateAdminStatusUser
{
    public class UpdateAdminStatusUserCommandHandler : IRequestHandler<UpdateAdminStatusUserCommand, Usuario>
    {
        private readonly UserManager<Usuario> _userManager;

        public UpdateAdminStatusUserCommandHandler(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Usuario> Handle(UpdateAdminStatusUserCommand request, CancellationToken cancellationToken)
        {
            var updateUsuario = await _userManager.FindByIdAsync(request.Id!);
            if(updateUsuario is null)
            {
                throw new BadRequestException("El usuario no existe");
            }

            updateUsuario.IsActive = !updateUsuario.IsActive;

            var resultado = await _userManager.UpdateAsync(updateUsuario);

            if(!resultado.Succeeded)
            {
                throw new Exception("No se pudo cambiar el estado del usuario");
            }

            return updateUsuario;
        }
    }
}