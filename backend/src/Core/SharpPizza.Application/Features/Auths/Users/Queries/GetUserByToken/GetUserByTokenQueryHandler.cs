using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharpPizza.Application.Contracts.Identity;
using SharpPizza.Application.Features.Addresses.Vms;
using SharpPizza.Application.Features.Auths.Users.Vms;
using SharpPizza.Application.Persistence;
using SharpPizza.Domain;

namespace SharpPizza.Application.Features.Auths.Users.Queries.GetUserByToken
{
    public class GetUserByTokenQueryHandler : IRequestHandler<GetUserByTokenQuery, AuthResponse>
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IAuthService _authService;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetUserByTokenQueryHandler(
            UserManager<Usuario> userManager, 
            IAuthService authService, 
            IUnitOfWork unitOfWork, 
            IMapper mapper
            )
        {
            _userManager = userManager;
            _authService = authService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthResponse> Handle(GetUserByTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(_authService.GetSessionUser());
            if(user is null)
            {
                throw new Exception("El usuario no esta autenticado");
            }
            
            if(!user.IsActive)
            {
                throw new Exception("El usuario esta bloqueado, contacte al admin");
            }

            var direccionEnvio = await _unitOfWork.Repository<Address>().GetEntityAsync(
                x => x.Username == user.UserName
            );       

            var roles = await _userManager.GetRolesAsync(user);

            return new AuthResponse
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Telefono = user.Telefono,
                Email = user.Email,
                Username = user.UserName,
                Avatar = user.AvatarUrl,
                DireccionEnvio =  _mapper.Map<AddressVm>(direccionEnvio),
                Token = _authService.CreateToken(user, roles),
                Roles = roles
            };

        }
    }
}