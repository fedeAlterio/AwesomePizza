namespace AwesomePizza.Models.Orders;

public readonly record struct OrderEventId(Guid Value)
{
    public static OrderEventId Create() => new(Guid.NewGuid());
}