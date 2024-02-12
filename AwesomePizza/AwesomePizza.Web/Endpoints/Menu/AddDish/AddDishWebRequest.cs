using MediatR;

namespace AwesomePizza.Web.Endpoints.Menu.AddDish;

public class AddDishWebRequest : IRequest<IResult>
{
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;
    public int? Price { get; init; } 
}
