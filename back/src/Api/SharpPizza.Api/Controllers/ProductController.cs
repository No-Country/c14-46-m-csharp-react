using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpPizza.Application.Contracts.Infrastructure;
using SharpPizza.Application.Features.Products.Commands.CreateProduct;
using SharpPizza.Application.Features.Products.Commands.DeleteProduct;
using SharpPizza.Application.Features.Products.Commands.UpdateProduct;
using SharpPizza.Application.Features.Products.Queries.GetProductById;
using SharpPizza.Application.Features.Products.Queries.GetProductList;
using SharpPizza.Application.Features.Products.Queries.PaginationProducts;
using SharpPizza.Application.Features.Products.Queries.Vms;
using SharpPizza.Application.Features.Shared.Queries;
using SharpPizza.Application.Models.Authorization;
using SharpPizza.Application.Models.ImageManagement;
using SharpPizza.Domain;

namespace SharpPizza.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;
        private IManageImageService _manageImageService;

        

        public ProductController(IMediator mediator, IManageImageService manageImageService)
        {
            _mediator = mediator;
            _manageImageService = manageImageService;
        }
        //Este endpoint sea consumido de manera public, no necesita estar loggeado ni credenciales de acceso gracias a AllowAnonymous
        [AllowAnonymous] 
        [HttpGet("list", Name = "GetProductList")]
        [ProducesResponseType(typeof(IReadOnlyList<ProductVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<ProductVm>>> GetProductList()
        {
            var query = new GetProductListQuery();
            var productos = await _mediator.Send(query);
        return Ok(productos);
        }

        [AllowAnonymous]
        [HttpGet("pagination", Name = "PaginationProduct")]
        [ProducesResponseType(typeof(PaginationVm<ProductVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<ProductVm>>> PaginationProduct(
            [FromQuery] PaginationProductsQuery paginationProductsQuery
        )
        {
            paginationProductsQuery.Status = ProductStatus.Activo;
            var paginationProduct = await _mediator.Send(paginationProductsQuery);
            return Ok(paginationProduct);
        }


        [Authorize(Roles = Role.ADMIN)]
        [HttpGet("paginationAdmin", Name = "PaginationProductAdmin")]
        [ProducesResponseType(typeof(PaginationVm<ProductVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<ProductVm>>> PaginationAdmin(
            [FromQuery] PaginationProductsQuery paginationProductsQuery
        )
        {
            var paginationProduct = await _mediator.Send(paginationProductsQuery);
            return Ok(paginationProduct);
        }

        
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVm>> GetProductById(int id)
        {
            var query = new GetProductByIdQuery(id);
            return Ok(await _mediator.Send(query));
        }


        [Authorize(Roles = Role.ADMIN)]
        [HttpPost("create", Name = "CreateProduct")]
        [ProducesResponseType( (int)HttpStatusCode.OK )]
        public async Task<ActionResult<ProductVm>> CreateProduct([FromForm] CreateProductCommand request)
        {
            var listFotoUrls = new List<CreateProductImageCommand>();

            if(request.Fotos is not null)
            {
                foreach(var foto in request.Fotos)
                {
                    var resultImage = await _manageImageService.UploadImage(new ImageData
                    {
                        ImageStream = foto.OpenReadStream(),
                        Nombre = foto.Name
                    });

                    var fotoCommand = new CreateProductImageCommand
                    {
                        PublicCode = resultImage.PublicId,
                        Url = resultImage.Url
                    };

                    listFotoUrls.Add(fotoCommand);
                }
                request.ImageUrls = listFotoUrls;
            }

            return await _mediator.Send(request);

        }


        [Authorize(Roles = Role.ADMIN)]
        [HttpPut("update", Name = "UpdateProduct")]
        [ProducesResponseType( (int)HttpStatusCode.OK )]
        public async Task<ActionResult<ProductVm>> UpdateProduct([FromForm] UpdateProductCommand request)
        {
            var listFotoUrls = new List<CreateProductImageCommand>();

            if(request.Fotos is not null)
            {
                foreach(var foto in request.Fotos)
                {
                    var resultImage = await _manageImageService.UploadImage(new ImageData
                    {
                        ImageStream = foto.OpenReadStream(),
                        Nombre = foto.Name
                    });

                    var fotoCommand = new CreateProductImageCommand
                    {
                        PublicCode = resultImage.PublicId,
                        Url = resultImage.Url
                    };

                    listFotoUrls.Add(fotoCommand);
                }
                request.ImageUrls = listFotoUrls;
            }

            return await _mediator.Send(request);

        }




        [Authorize(Roles = Role.ADMIN)]
        [HttpDelete("status/{id}", Name = "UpdateStatusProduct")]
        [ProducesResponseType( (int)HttpStatusCode.OK )]
        public async Task<ActionResult<ProductVm>> UpdateStatusProduct(int id)
        {
            var request = new DeleteProductCommand(id);
            return await _mediator.Send(request);
        }
    }
}