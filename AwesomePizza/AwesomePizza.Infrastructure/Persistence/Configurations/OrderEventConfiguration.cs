using AwesomePizza.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomePizza.Infrastructure.Persistence.Configurations;

internal class OrderEventConfiguration : IEntityTypeConfiguration<OrderEvent>
{
    public void Configure(EntityTypeBuilder<OrderEvent> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne<Order>()
               .WithMany()
               .HasForeignKey(x => x.OrderId);

        builder.Property(x => x.Id)
               .HasConversion(x => x.Value, x => new(x));
    }
}