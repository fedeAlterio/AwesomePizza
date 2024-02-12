using AwesomePizza.Web.Dto;

namespace AwesomePizza.Web.Endpoints.Orders.LastOrderToBeCompleted;
public class LastOrderToBeCompletedWebResponse
{
    public required OrderEventDto? OrderEvent { get; init; }
    public static LastOrderToBeCompletedWebResponse Empty => new()
    {
        OrderEvent = null
    };
}
