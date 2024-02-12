using AwesomePizza.Models.Dishes;
using AwesomePizza.Models.Validation;
using FluentValidation;

namespace AwesomePizza.Models.Orders;
public class Order
{
    public required OrderId Id { get; init; }
    public required List<OrderDishWithQuantity> Dishes { get; init; }

    public static Order Create(List<Dish> dishes) => new()
    {
        Id = OrderId.Create(),
        Dishes = dishes.GroupBy(x => x)
                       .Select(x => new OrderDishWithQuantity(OrderDishWithQuantityId.Create(), x.Count())
                       {
                           Dish = x.Key
                       })
                       .ToList()
    };
}

public class OrderDishWithQuantity
{
    public OrderDishWithQuantity(OrderDishWithQuantityId id, int quantity)
    {
        Id = id;
        Quantity = quantity;

        this.ValidatePropertiesOrThrow(@this =>
        {
            @this.RuleFor(x => x.Quantity)
                 .GreaterThan(0);
        });
    }

    public OrderDishWithQuantityId Id { get; }
    public int Quantity { get; }
    public Dish Dish { get; init; } = null!;
}