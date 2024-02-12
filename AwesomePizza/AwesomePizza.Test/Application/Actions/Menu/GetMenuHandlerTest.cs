using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Application.Actions.Menu.GetMenu;
using AwesomePizza.Models.Dishes;
using AwesomePizza.Test.TestHelpers;
using FluentAssertions;
using Moq;

namespace AwesomePizza.Test.Application.Actions.Menu;
public class GetMenuHandlerTest
{
    [Fact]
    public async Task ShouldReturn_RepositoryDishes()
    {
        List<Dish> dishes = 
            MockData.GetGuids()
                         .Select(x => new Dish(new(x), new DishName(x.ToString()), new(x.ToString()), new(16)))
                         .ToList();

        var handler = GetHandler(repository =>
        {
            repository.Setup(x => x.GetAllDishes(default))
                      .ReturnsAsync(dishes);
        });

        var response = await handler.Handle(new(), CancellationToken.None);
        response.Dishes.Should().BeEquivalentTo(dishes);
    }


    static GetMenuHandler GetHandler(Action<Mock<IDishRepository>> dishRepositoryConfig)
    {
        var mock = new Mock<IDishRepository>(MockBehavior.Strict);
        dishRepositoryConfig(mock);
        return new GetMenuHandler(mock.Object);
    }
}
