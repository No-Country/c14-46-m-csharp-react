using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharpPizza.Application.Contracts.Identity;
using SharpPizza.Application.Exceptions;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Auths.Users.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IAuthService _authService;

        public ResetPasswordCommandHandler(UserManager<Usuario> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var updateUsuario = await _userManager.FindByNameAsync(_authService.GetSessionUser());
            if(updateUsuario is null)
            {
                throw new BadRequestException("El usuario no existe");
            }

            var resultValidateOldPassword = _userManager.PasswordHasher
                .VerifyHashedPassword(updateUsuario, updateUsuario.PasswordHash!, request.OldPassword!);

            if(  !(resultValidateOldPassword == PasswordVerificationResult.Success)  )
            {
                throw new BadRequestException("El actual password ingresado es erroneo");
            }

            var hashedNewPassword = _userManager.PasswordHasher.HashPassword(updateUsuario, request.NewPassword!);
            updateUsuario.PasswordHash = hashedNewPassword;

            var resultado = await _userManager.UpdateAsync(updateUsuario);

            if(!resultado.Succeeded)
            {
                throw new Exception("No se pudo resetear el password");
            }

            return Unit.Value;              
        } 
    }
}