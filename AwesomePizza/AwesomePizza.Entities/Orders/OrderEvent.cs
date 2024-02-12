namespace AwesomePizza.Models.Orders;

public record OrderEvent
{
    public required OrderId OrderId { get; init; }
    public required OrderEventId Id { get; init; }
    public required DateTime DateUtc { get; init; }
    public required OrderEventType Type { get; init; }

    public static OrderEvent CreateForNewOrder(OrderId orderId) => new()
    {
        Id = OrderEventId.Create(),
        DateUtc = DateTime.UtcNow,
        OrderId = orderId,
        Type = OrderEventType.Created
    };
}

public static class OrderEventEx
{
    public static OrderEvent ChangeState(this OrderEvent orderEvent, OrderEventType type) => orderEvent with
    {
        Id = OrderEventId.Create(),
        Type = type,
        DateUtc = DateTime.UtcNow
    };
}