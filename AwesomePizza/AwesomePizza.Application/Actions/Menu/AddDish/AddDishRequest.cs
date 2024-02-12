using AwesomePizza.Application.Actions.Abstractions;
using AwesomePizza.Models.Dishes;
using MediatR;

namespace AwesomePizza.Application.Actions.Menu.AddDish;
public class AddDishRequest : IRequest<AddDishResponse>, ICommand
{
    public required DishName DishName { get; init; }
    public required DishDescription Description { get; init; }
    public required DishPrice Price { get; init; }
}
