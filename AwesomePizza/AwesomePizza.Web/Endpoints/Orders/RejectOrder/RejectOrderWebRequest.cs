using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.RejectOrder;
public class RejectOrderWebRequest : IRequest<IResult>
{
    public Guid? OrderId { get; init; }
}
