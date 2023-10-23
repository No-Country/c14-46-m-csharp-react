using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharpPizza.Application.Contracts.Identity;
using SharpPizza.Application.Exceptions;
using SharpPizza.Application.Features.Addresses.Vms;
using SharpPizza.Application.Features.Auths.Users.Vms;
using SharpPizza.Application.Persistence;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Auths.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AuthResponse>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _sigInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IAuthService _authService;
        
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public LoginUserCommandHandler(
                            UserManager<Usuario> userManager, 
                            SignInManager<Usuario> sigInManager, 
                            RoleManager<IdentityRole> roleManager, 
                            IAuthService authService, 
                            IMapper mapper, 
                            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _sigInManager = sigInManager;
            _roleManager = roleManager;
            _authService = authService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email!);
            if(user is null)
            {
                throw new NotFoundException(nameof(Usuario), request.Email!);
            }

            if(!user.IsActive)
            {
                throw new Exception($"El usuario esta bloqueado, contacte al admin");
            }

            var resultado = await _sigInManager.CheckPasswordSignInAsync(user, request.Password!, false);

            if(!resultado.Succeeded)
            {
                throw new Exception("Las credenciales del usuario son erroneas");
            }

            var direccionEnvio = await _unitOfWork.Repository<Address>().GetEntityAsync(
                x => x.Username == user.UserName
            );

            var roles = await _userManager.GetRolesAsync(user);

            var authResponse = new AuthResponse
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Telefono = user.Telefono,
                Email = user.Email,
                Username = user.UserName,
                Avatar = user.AvatarUrl,
                DireccionEnvio = _mapper.Map<AddressVm>(direccionEnvio),
                Token = _authService.CreateToken(user, roles),
                Roles = roles           
            };

            return authResponse;
        }
    }
}