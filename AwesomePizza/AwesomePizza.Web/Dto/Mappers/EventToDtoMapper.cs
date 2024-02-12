using AwesomePizza.Models.Orders;

namespace AwesomePizza.Web.Dto.Mappers;

public static class EventToDtoMapper
{
    public static OrderEventDto ToDto(this OrderEvent orderEvent) => new()
    {
        OrderEventId = orderEvent.Id.Value,
        DateUtc = orderEvent.DateUtc,
        OrderId = orderEvent.OrderId.Value,
        EventType = orderEvent.Type.ToDto(),
    };
}
