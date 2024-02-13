using AwesomePizza.Models.Dishes;
using MediatR;

namespace AwesomePizza.Application.Actions.Menu.RemoveDish;
public class RemoveDishRequest : IRequest<RemoveDishResponse>
{
    public required DishId DishId { get; init; }
}
