using AwesomePizza.Application.Abstractions.Repositories;
using MediatR;

namespace AwesomePizza.Application.Actions.Menu.GetMenu;
public class GetMenuHandler(IDishRepository dishRepository) : IRequestHandler<GetMenuRequest, GetMenuResponse>
{
    public async Task<GetMenuResponse> Handle(GetMenuRequest request, CancellationToken cancellationToken)
    {
        var dishes = await dishRepository.GetAllDishes(cancellationToken);
        return new GetMenuResponse
        {
            Dishes = dishes
        };
    }
}
