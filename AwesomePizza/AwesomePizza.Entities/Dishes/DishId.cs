namespace AwesomePizza.Models.Dishes;

public readonly record struct DishId(Guid Value)
{
    public static DishId Create() => new(Guid.NewGuid());
}