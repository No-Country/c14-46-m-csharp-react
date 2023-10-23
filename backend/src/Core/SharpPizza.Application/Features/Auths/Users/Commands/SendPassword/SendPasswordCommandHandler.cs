using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharpPizza.Application.Contracts.Infrastructure;
using SharpPizza.Application.Exceptions;
using SharpPizza.Application.Models.Email;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Auths.Users.Commands.SendPassword
{
    public class SendPasswordCommandHandler : IRequestHandler<SendPasswordCommand, string>
    {
        private readonly IEmailService _serviceEmail;
        private readonly UserManager<Usuario> _userManager;

        public SendPasswordCommandHandler(IEmailService serviceEmail, UserManager<Usuario> userManager)
        {
            _serviceEmail = serviceEmail;
            _userManager = userManager;
        }

        public async Task<string> Handle(SendPasswordCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _userManager.FindByEmailAsync(request.Email!);
            if(usuario is null)
            {
                throw new BadRequestException("El usuario no existe");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
            var plainTextBytes = Encoding.UTF8.GetBytes(token);
            token = Convert.ToBase64String(plainTextBytes);

            var emailMessage = new EmailMessage 
            {
                To = request.Email,
                Body = "Resetear el password, dale click aqui:",
                Subject = "Cambiar el password"
            };

            var result = await _serviceEmail.SendEmail(emailMessage, token);

            if(!result)
            {
                throw new Exception("No se pudo enviar el email");
            }

            return $"Se envio el email a la cuenta {request.Email}";
        }
    }
}