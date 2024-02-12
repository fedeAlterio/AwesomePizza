namespace AwesomePizza.Web.Dto;

public class OrderSummaryDto
{
    public required OrderDto Order { get; init; }
    public required OrderEventDto LastOrderEvent { get; init; }
}
