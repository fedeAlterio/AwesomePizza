using AwesomePizza.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomePizza.Infrastructure.Persistence.Configurations;
internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasConversion(x => x.Value, x => new(x));

        builder.HasMany(x => x.Dishes)
               .WithOne();
    }
}