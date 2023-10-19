using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SharpPizza.Domain.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        //Relaciones
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.OrderAddress, x => {
                x.WithOwner();
            });

            builder.HasMany(o => o.OrderItems).WithOne()
            .OnDelete(DeleteBehavior.Cascade);

            builder.Property(s => s.Status).HasConversion(
                o => o.ToString(),
                o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
            );
        }
    }
}