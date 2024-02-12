using MediatR;

namespace AwesomePizza.Web.Endpoints.Orders.CreateOrder;
public class CreateOrderWebRequest : IRequest<IResult>
{
    public IReadOnlyCollection<Guid> Dishes { get; init; } = null!;
}
