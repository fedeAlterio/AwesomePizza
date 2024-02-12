using AwesomePizza.Models.Orders;

namespace AwesomePizza.Web.Dto.Mappers;

public static class OrderEventTypeToDtoMapper
{
    public static OrderEventTypeDto ToDto(this OrderEventType type) => type switch
    {
        OrderEventType.Created => OrderEventTypeDto.Created,
        OrderEventType.Completed => OrderEventTypeDto.Completed,
        OrderEventType.InProgress => OrderEventTypeDto.InProgress,
        OrderEventType.Rejected => OrderEventTypeDto.Rejected,
        _ => throw new ArgumentOutOfRangeException(nameof(type))
    };
}
