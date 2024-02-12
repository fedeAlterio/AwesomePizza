namespace AwesomePizza.Models.Orders;

public readonly record struct OrderDishWithQuantityId(Guid Value)
{
    public static OrderDishWithQuantityId Create() => new(Guid.NewGuid());
}