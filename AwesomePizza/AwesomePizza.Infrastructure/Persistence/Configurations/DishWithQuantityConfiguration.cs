using AwesomePizza.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomePizza.Infrastructure.Persistence.Configurations;

internal class DishWithQuantityConfiguration : IEntityTypeConfiguration<OrderDishWithQuantity>
{
    public void Configure(EntityTypeBuilder<OrderDishWithQuantity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
               .HasConversion(x => x.Value, x => new(x));

        builder.Property(x => x.Quantity);
    }
}