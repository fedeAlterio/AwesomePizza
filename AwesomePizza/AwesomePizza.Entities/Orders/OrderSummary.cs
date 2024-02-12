namespace AwesomePizza.Models.Orders;
public class OrderSummary
{
    public required Order Order { get; init; }
    public required OrderEvent LastOrderEvent { get; init; }
}
