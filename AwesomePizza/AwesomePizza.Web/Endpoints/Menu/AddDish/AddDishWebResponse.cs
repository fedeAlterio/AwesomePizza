
using System.ComponentModel;

namespace AwesomePizza.Web.Endpoints.Menu.AddDish;

[DisplayName("AddDishResponse")]
public class AddDishWebResponse
{
    public required Guid DishId { get; init; }
}
