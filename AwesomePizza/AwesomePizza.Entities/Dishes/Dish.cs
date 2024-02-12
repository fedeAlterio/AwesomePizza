using AwesomePizza.Models.Validation;
using FluentValidation;

namespace AwesomePizza.Models.Dishes;

public record Dish
{
    public Dish(DishId id, DishName name, DishDescription description, DishPrice price)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;

        this.ValidatePropertiesOrThrow(@this =>
        {
            @this.RuleFor(x => x.Name)
                 .NotNull();

            @this.RuleFor(x => x.Description)
                 .NotNull();
        });
    }

    public DishId Id { get;  }
    public DishName Name { get;  }
    public DishDescription Description { get;  }
    public DishPrice Price { get;  }
}