namespace AwesomePizza.Models.Orders;

public readonly record struct OrderId(Guid Value)
{
    public static OrderId Create() => new(Guid.NewGuid());
}