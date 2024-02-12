using AwesomePizza.Models.Dishes;

namespace AwesomePizza.Application.Actions.Menu.GetMenu;

public class GetMenuResponse
{
    public required IReadOnlyList<Dish> Dishes { get; init; }
}
