using AwesomePizza.Models.Dishes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomePizza.Infrastructure.Persistence.Configurations;
internal class DishConfiguration : IEntityTypeConfiguration<Dish>
{
    public void Configure(EntityTypeBuilder<Dish> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasConversion(x => x.Value, x => new(x));

        builder.HasIndex(x => x.Name)
               .IsUnique();

        builder.Property(x => x.Name)
               .HasMaxLength(DishName.MAXIMUM_LENGTH)
               .HasConversion(x => x.Value, x => new(x));

        builder.Property(x => x.Description)
               .HasMaxLength(DishDescription.MAXIMUM_LENGTH)
               .HasConversion(x => x.Value, x => new(x));

        builder.Property(x => x.Price)
               .HasConversion(x => x.Value, x => new(x));
    }
}