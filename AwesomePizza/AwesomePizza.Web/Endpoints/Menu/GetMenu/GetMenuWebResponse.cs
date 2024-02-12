using System.ComponentModel;
using AwesomePizza.Web.Dto;

namespace AwesomePizza.Web.Endpoints.Menu.GetMenu;

[DisplayName("MenuResponse")]
public class GetMenuWebResponse
{
    public required IEnumerable<DishDto> Dishes { get; init; }
}
