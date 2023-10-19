using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharpPizza.Application.Features.Auths.Users.Vms;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Auths.Users.Queries.GetUserByUsername
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, AuthResponse>
    {
        private readonly UserManager<Usuario> _userManager;

        public GetUserByUsernameQueryHandler(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AuthResponse> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username!);
            
            if (user is null)
            {
                throw new Exception($"El usuario no existe");
            }

            return new AuthResponse
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Telefono = user.Telefono,
                Email = user.Email,
                Username = user.UserName,
                Avatar = user.AvatarUrl,
                Roles = await _userManager.GetRolesAsync(user)
            };

        }
    }
}