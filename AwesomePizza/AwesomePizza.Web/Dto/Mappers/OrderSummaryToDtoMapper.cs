using AwesomePizza.Models.Orders;

namespace AwesomePizza.Web.Dto.Mappers;

public static class OrderSummaryToDtoMapper
{
    public static OrderSummaryDto ToDto(this OrderSummary orderSummary) => new()
    {
        LastOrderEvent = orderSummary.LastOrderEvent.ToDto(),
        Order = orderSummary.Order.ToDto()
    };
}
