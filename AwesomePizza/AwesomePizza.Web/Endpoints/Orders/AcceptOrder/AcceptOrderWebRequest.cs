using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.AcceptOrder;
public class AcceptOrderWebRequest : IRequest<IResult>
{
    public Guid? OrderId { get; init; }
}
