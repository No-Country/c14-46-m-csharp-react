using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SharpPizza.Application.Features.Addresses.Vms;
using SharpPizza.Application.Features.Categories.Vms;
using SharpPizza.Application.Features.Countries.Vms;
using SharpPizza.Application.Features.Images.Queries;
using SharpPizza.Application.Features.Orders.Vms;
using SharpPizza.Application.Features.Products.Commands.CreateProduct;
using SharpPizza.Application.Features.Products.Commands.UpdateProduct;
using SharpPizza.Application.Features.Products.Queries.Vms;
using SharpPizza.Application.Features.Reviews.Queries.Vms;
using SharpPizza.Application.Features.ShoppingCarts.Vms;
using SharpPizza.Domain;

namespace SharpPizza.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        CreateMap<Product, ProductVm>()
                .ForMember(p=> p.CategoryNombre, x=> x.MapFrom(a => a.Category!.Nombre))
                .ForMember(p => p.NumeroReviews, x => x.MapFrom(a => a.Reviews == null ? 0 : a.Reviews.Count));

        CreateMap<Image, ImageVm>();
        CreateMap<Review, ReviewVm>();
        CreateMap<Country, CountryVm>();
        CreateMap<Category, CategoryVm>();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<CreateProductImageCommand, Image>();
        CreateMap<UpdateProductCommand, Product>();

            CreateMap<ShoppingCart, ShoppingCartVm>()
                    .ForMember(p => p.ShoppingCartId, x => x.MapFrom(a => a.ShoppingCartMasterId));
                    
            CreateMap<ShoppingCartItem, ShoppingCartItemVm>();

            CreateMap<ShoppingCartItemVm, ShoppingCartItem>();
            CreateMap<Address, AddressVm>();

            CreateMap<Order, OrderVm>();
            CreateMap<OrderItem, OrderItemVm>();
            CreateMap<OrderAddress, AddressVm>();
        }
    }
}