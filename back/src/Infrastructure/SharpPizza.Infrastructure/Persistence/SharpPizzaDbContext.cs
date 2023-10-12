using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharpPizza.Domain;

namespace SharpPizza.Infrastructure.Persistence
{
    public class SharpPizzaDbContext : DbContext
    {
        public SharpPizzaDbContext()
        {
            
        }
        public SharpPizzaDbContext(DbContextOptions<SharpPizzaDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.Entity<PizzaIngrediente>()
                .HasKey(x => new { x.PizzaId, x.IngredienteId });

            base.OnModelCreating(modelbuilder);

        }


        public DbSet<Pizza>? Pizzas { get; set; }

        public DbSet<Ingrediente>? Ingredientes { get; set; }

        public DbSet<PizzaIngrediente>? PizzasIngredientes { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
