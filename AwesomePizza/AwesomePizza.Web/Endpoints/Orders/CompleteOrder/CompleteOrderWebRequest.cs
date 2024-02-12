using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.CompleteOrder;
public class CompleteOrderWebRequest : IRequest<IResult>
{
    public required Guid? OrderId { get; init; }
}
