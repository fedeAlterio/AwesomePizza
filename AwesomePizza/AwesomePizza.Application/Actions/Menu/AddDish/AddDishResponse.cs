using AwesomePizza.Models.Dishes;
using OneOf;

namespace AwesomePizza.Application.Actions.Menu.AddDish;

[GenerateOneOf]
public partial class AddDishResponse : OneOfBase<AddDishSuccessResponse, DishWithSameNameAlreadyExists>;
public record AddDishSuccessResponse
{
    public required DishId DishId { get; init; }
}

public record DishWithSameNameAlreadyExists(DishName DishName);
