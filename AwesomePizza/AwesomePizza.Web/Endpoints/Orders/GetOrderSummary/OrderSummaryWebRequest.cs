using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.GetOrderSummary;
public class OrderSummaryWebRequest : IRequest<IResult>
{
    public Guid? OrderId { get; init; }
}
