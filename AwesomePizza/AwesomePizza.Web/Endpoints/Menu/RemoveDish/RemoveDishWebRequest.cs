using AwesomePizza.Models.Dishes;
using MediatR;

namespace AwesomePizza.Web.Endpoints.Menu.RemoveDish;
public class RemoveDishWebRequest : IRequest<IResult>
{
    public Guid? DishId { get; init; }
}
