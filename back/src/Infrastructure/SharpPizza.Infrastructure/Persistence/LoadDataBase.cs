using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPizza.Domain;

namespace SharpPizza.Infrastructure.Persistence
{
    public class LoadDataBase
    {
        public static async Task InsertarData(SharpPizzaDbContext context) 
        {
            if (!context.Users.Any()) 
            {
                await context.Users.AddRangeAsync(
                    new User
                    {
                        UserName = "Leon",
                        Name = "Angelo",
                        Email = "angelo-pc@outlook.es",
                        Address = "Cra 5a",
                        Password = "Prueba-123",
                        Phone = "9999",
                        Rol = "ADMIN",
                        ImageUrl = "dlasdhkashdl.jpg"
                    },
                    new User
                    {
                        UserName = "PepLeon",
                        Name = "Pepe",
                        Email = "pepe-pc@outlook.es",
                        Address = "Cra 5b",
                        Password = "Prueba-456",
                        Phone = "8888",
                        Rol = "ADMIN",
                        ImageUrl = "ddas.jpg"
                    },
                    new User
                    {
                        UserName = "KilLeon",
                        Name = "Kil",
                        Email = "kil-pc@outlook.es",
                        Address = "Cra 5c",
                        Password = "Prueba-789",
                        Phone = "9999",
                        Rol = "UserBasic",
                        ImageUrl = "dbbb.jpg"
                    }
                    );

                await context.SaveChangesAsync();
            }
        }
    }
}
