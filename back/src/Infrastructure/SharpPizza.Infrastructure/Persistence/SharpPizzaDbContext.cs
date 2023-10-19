using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SharpPizza.Domain;
using SharpPizza.Domain.Common;

namespace SharpPizza.Infrastructure.Persistence
{
    public class SharpPizzaDbContext : IdentityDbContext<Usuario>
    {
        public SharpPizzaDbContext(DbContextOptions<SharpPizzaDbContext> options) : base(options)
        {

        }

    // Auditoria en que hora, dia fecha se genero este record, quien lo genero y en que fecha se actualizo.
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
    {
        var userName = "system";

        foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
        {
            switch(entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = userName;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = userName;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(r => r.Category)
                .HasForeignKey(r => r.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            

            builder.Entity<Product>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.Entity<ShoppingCart>()
            .HasMany(p => p.ShoppingCartItems)
            .WithOne(r => r.ShoppingCart)
            .HasForeignKey(r => r.ShoppingCartId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Usuario>().Property(x => x.Id).HasMaxLength(36); //250
            builder.Entity<Usuario>().Property(x => x.NormalizedUserName).HasMaxLength(90);
            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(36);
            builder.Entity<IdentityRole>().Property(x => x.NormalizedName).HasMaxLength(90);
        }











        public DbSet<Product>? Products { get; set; }    
        public DbSet<Category>? Categories {get;set;}
        public DbSet<Image>? Images { get; set; }
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<Review>? Reviews { get; set; }
        public DbSet<ShoppingCart>? ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public DbSet<Country>? Countries { get; set; }
        public DbSet<OrderAddress>? OrderAddresses { get; set; }
    }
}