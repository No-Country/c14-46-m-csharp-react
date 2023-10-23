using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpPizza.Application.Contracts.Infrastructure;
using SharpPizza.Application.Features.Auths.Roles.Queries.GetRoles;
using SharpPizza.Application.Features.Auths.Users.Commands.LoginUser;
using SharpPizza.Application.Features.Auths.Users.Commands.RegisterUser;
using SharpPizza.Application.Features.Auths.Users.Commands.ResetPassword;
using SharpPizza.Application.Features.Auths.Users.Commands.ResetPasswordByToken;
using SharpPizza.Application.Features.Auths.Users.Commands.SendPassword;
using SharpPizza.Application.Features.Auths.Users.Commands.UpdateAdminStatusUser;
using SharpPizza.Application.Features.Auths.Users.Commands.UpdateAdminUser;
using SharpPizza.Application.Features.Auths.Users.Commands.UpdateUser;
using SharpPizza.Application.Features.Auths.Users.Queries.GetUserById;
using SharpPizza.Application.Features.Auths.Users.Queries.GetUserByToken;
using SharpPizza.Application.Features.Auths.Users.Queries.GetUserByUsername;
using SharpPizza.Application.Features.Auths.Users.Queries.PaginationUsers;
using SharpPizza.Application.Features.Auths.Users.Vms;
using SharpPizza.Application.Features.Shared.Queries;
using SharpPizza.Application.Models.Authorization;
using SharpPizza.Application.Models.ImageManagement;
using SharpPizza.Domain;

namespace SharpPizza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IMediator _mediator;
        private IManageImageService _manageImageService;

        public UsuarioController(IMediator mediator, IManageImageService manageImageService)
        {
            _mediator = mediator;
            _manageImageService = manageImageService;
        }

        [AllowAnonymous]
        [HttpPost("login", Name = "Login")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginUserCommand request)
        {
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("register", Name = "Register")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> Register([FromForm] RegisterUserCommand request)
        {
            if(request.Foto is not null)
            {
                var resultImage = await _manageImageService.UploadImage(new ImageData
                {
                    ImageStream = request.Foto!.OpenReadStream(),
                    Nombre = request.Foto.Name
                }
                );

                request.FotoId = resultImage.PublicId;
                request.FotoUrl = resultImage.Url;
            }

            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("forgotpassword", Name = "ForgotPassword")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> ForgotPassword([FromBody] SendPasswordCommand request)
        {
            return await _mediator.Send(request);
        }

        [AllowAnonymous]
        [HttpPost("resetpassword", Name = "ResetPassword")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordByTokenCommand request)
        {
            return await _mediator.Send(request);
        }

        
        [HttpPost("updatepassword", Name = "UpdatePassword")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Unit>> UpdatePassword([FromBody] ResetPasswordCommand request)
        {
            return await _mediator.Send(request);
        }


        [HttpPut("update", Name = "Update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> Update([FromForm] UpdateUserCommand request)
        {
            
            if(request.Foto is not null)
            {
                var resultImage = await _manageImageService.UploadImage( new ImageData 
                {
                    ImageStream = request.Foto!.OpenReadStream(),
                    Nombre = request.Foto!.Name
                }
                );

                request.FotoId =  resultImage.PublicId;
                request.FotoUrl = resultImage.Url;
            }
            
            
            return await _mediator.Send(request);
        }


        // Solo los admin pueden acceder aqui gracias a Authorize
        [Authorize(Roles = Role.ADMIN)]
        [HttpPut("updateAdminUser", Name = "UpdateAdminUser")]
        [ProducesResponseType(typeof(Usuario), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Usuario>> UpdateAdminUser([FromBody] UpdateAdminUserCommand request)
        {
            return await _mediator.Send(request);
        }


        [Authorize(Roles = Role.ADMIN)]
        [HttpPut("updateAdminStastusUser", Name = "UpdateAdminStastusUser")]
        [ProducesResponseType(typeof(Usuario), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Usuario>> UpdateAdminStastusUser([FromBody] UpdateAdminStatusUserCommand request)
        {
            return await _mediator.Send(request);
        }


        [Authorize(Roles = Role.ADMIN)]
        [HttpGet("{id}", Name = "GetUsuarioById")]
        [ProducesResponseType(typeof(AuthResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> GetUsuarioById(string id)
        {
            var query = new GetUserByIdQuery(id);
            return await _mediator.Send(query);
        }


        
        [HttpGet("", Name = "CurrentUser")]
        [ProducesResponseType(typeof(AuthResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> CurrentUser()
        {
            var query = new GetUserByTokenQuery();
            return await _mediator.Send(query);
        }


        [Authorize(Roles = Role.ADMIN)]
        [HttpGet("username/{username}", Name = "GetUsuarioByUsername")]
        [ProducesResponseType(typeof(AuthResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthResponse>> GetUsuarioByUsername(string username)
        {
            var query = new GetUserByUsernameQuery(username);
            return await _mediator.Send(query);
        }


        [Authorize(Roles = Role.ADMIN)]
        [HttpGet("paginationAdmin", Name = "PaginationUser")]
        [ProducesResponseType(typeof(PaginationVm<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<Usuario>>> PaginationUser(
                        [FromQuery] PaginationUsersQuery paginationUsersQuery
                    )
        {
            var paginationUser = await _mediator.Send(paginationUsersQuery);
            return Ok(paginationUser);
        }


        [AllowAnonymous]
        [HttpGet("roles", Name = "GetRolesList")]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<string>>>  GetRolesList()
        {
            var query = new GetRolesQuery();
            return Ok(await _mediator.Send(query));

        }
    }
}