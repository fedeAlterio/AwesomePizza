using AwesomePizza.Models.Dishes;

namespace AwesomePizza.Web.Dto.Mappers;

public static class DishToDtoMapper
{
    public static DishDto ToDto(this Dish dish) => new()
    {
        Id = dish.Id.Value,
        Name = dish.Name.Value,
        Description = dish.Description.Value,
        Price = dish.Price.Value
    };
}
