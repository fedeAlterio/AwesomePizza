using AwesomePizza.Application.Actions.Abstractions;
using AwesomePizza.Models.Dishes;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.CreateOrder;
public class CreateOrderRequest : IRequest<CreateOrderResponse>, ICommand
{
    public required List<DishId> Dishes { get; init; }
}
