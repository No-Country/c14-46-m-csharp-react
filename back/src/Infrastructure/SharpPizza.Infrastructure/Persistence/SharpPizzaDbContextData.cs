using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharpPizza.Application.Models.Authorization;
using SharpPizza.Domain;

namespace SharpPizza.Infrastructure.Persistence
{
    public class SharpPizzaDbContextData
    {
            public static async Task LoadDataAsync(
            SharpPizzaDbContext context,
            UserManager<Usuario> usuarioManager,
            RoleManager<IdentityRole> roleManager,
            ILoggerFactory loggerFactory
        )
        {
            try
            {
                if(!roleManager.Roles.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
                    await roleManager.CreateAsync(new IdentityRole(Role.USER));
                }

                if(!usuarioManager.Users.Any())
                {
                    var usuarioAdmin = new Usuario
                    {
                        Nombre = "Angelo",
                        Apellido = "Otalvaro",
                        Email = "angelo-pc@outlook.es",
                        UserName = "LeonPizza",
                        Telefono = "111111",
                        AvatarUrl = "",
                    };
                    await usuarioManager.CreateAsync(usuarioAdmin, "Prueba-123$");
                    await usuarioManager.AddToRoleAsync(usuarioAdmin, Role.ADMIN);

                    var usuario = new Usuario
                    {
                        Nombre = "Juanita",
                        Apellido = "Perez",
                        Email = "juanita.perez@gmail.com",
                        UserName = "JuanitaPerezPizza",
                        Telefono = "555555",
                        AvatarUrl = "",
                    };
                    await usuarioManager.CreateAsync(usuario, "PasswordJuanitaPerez123$");
                    await usuarioManager.AddToRoleAsync(usuario, Role.USER);

                }

                if(!context.Categories!.Any())
                {
                    var categoryData = File.ReadAllText("../Infrastructure/SharpPizza.Infrastructure/Data/category.json");
                    var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                    await context.Categories!.AddRangeAsync(categories!);
                    await context.SaveChangesAsync();
                }

                if (!context.Products!.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/SharpPizza.Infrastructure/Data/product.json");
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                    await context.Products!.AddRangeAsync(products!);
                    await context.SaveChangesAsync();
                }

                if (!context.Images!.Any())
                {
                    var imageData = File.ReadAllText("../Infrastructure/SharpPizza.Infrastructure/Data/image.json");
                    var imagenes = JsonConvert.DeserializeObject<List<Image>>(imageData);
                    await context.Images!.AddRangeAsync(imagenes!);
                    await context.SaveChangesAsync();
                }

                if (!context.Reviews!.Any())
                {
                    var reviewData = File.ReadAllText("../Infrastructure/SharpPizza.Infrastructure/Data/review.json");
                    var reviews = JsonConvert.DeserializeObject<List<Review>>(reviewData);
                    await context.Reviews!.AddRangeAsync(reviews!);
                    await context.SaveChangesAsync();
                }


                if (!context.Countries!.Any())
                {
                    var countryData = File.ReadAllText("../Infrastructure/SharpPizza.Infrastructure/Data/countries.json");
                    var countries = JsonConvert.DeserializeObject<List<Country>>(countryData);
                    await context.Countries!.AddRangeAsync(countries!);
                    await context.SaveChangesAsync();
                }

            
            }
            catch(Exception e)
            {
                var logger = loggerFactory.CreateLogger<SharpPizzaDbContextData>();
                logger.LogError(e.Message);
            }

        }
    }
}