using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpPizza.Application.Contracts.Identity;
using SharpPizza.Application.Contracts.Infrastructure;
using SharpPizza.Application.Models.Email;
using SharpPizza.Application.Models.ImageManagement;
using SharpPizza.Application.Models.Payment;
using SharpPizza.Application.Models.Token;
using SharpPizza.Application.Persistence;
using SharpPizza.Infrastructure.MessageImplementation;
using SharpPizza.Infrastructure.Persistence.Repositories;
using SharpPizza.Infrastructure.Services.Auth;

namespace SharpPizza.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                                                                    IConfiguration configuration
        )//this IServiceCollection services,
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAuthService, AuthService>();

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<StripeSettings>(configuration.GetSection("StripeSettings"));
            return services;
        }
    }
}