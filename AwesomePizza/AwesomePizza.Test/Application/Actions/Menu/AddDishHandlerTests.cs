using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Application.Actions.Menu.AddDish;
using AwesomePizza.Models.Dishes;
using FluentAssertions;
using Moq;

namespace AwesomePizza.Test.Application.Actions.Menu;
public class AddDishHandlerTests
{
    [Theory]
    [InlineData("Pizza1")]
    [InlineData("Pizza 2")]
    public async Task ShouldReturnDishWithSameNameAlreadyExistsError_IfADishWithSameNameAlreadyExists(string dish)
    {
        var dishName = new DishName(dish);
        var handler = CreateHandler(repository =>
        {
            repository.Setup(x => x.DishWithNameExists(dishName))
                      .ReturnsAsync(true);
        });

        var request = new AddDishRequest
        {
            DishName = dishName,
            Description = new("Description"),
            Price = new(11)
        };

        var response = await handler.Handle(request, CancellationToken.None);
        response.Value.Should().BeOfType<DishWithSameNameAlreadyExists>();
    }

    [Theory]
    [InlineData("Pizza1")]
    [InlineData("Pizza 2")]
    public async Task ShouldPassCorrectInfo_IfSuccess(string dishName)
    {
        var request = new AddDishRequest
        {
            DishName = new(dishName),
            Description = new("Description"),
            Price = new(11)
        };

        Dish? passedDish = null;
        var handler = CreateHandler(repository =>
        {
            repository.Setup(x => x.DishWithNameExists(request.DishName))
                      .ReturnsAsync(false);

            repository.Setup(x => x.CreateDish(It.IsAny<Dish>()))
                      .Callback((Dish dish) => passedDish = dish);
        });

        var response = await handler.Handle(request, CancellationToken.None);
        passedDish.Should().NotBeNull();
        response.Value.Should().BeOfType<AddDishSuccessResponse>();
        (passedDish!.Description, passedDish.Name, passedDish.Price).Should().Be(
            (request.Description, request.DishName, request.Price));
    }

    static AddDishHandler CreateHandler(Action<Mock<IDishRepository>> setup)
    {
        var repositoryMock = new Mock<IDishRepository>(MockBehavior.Strict);
        setup(repositoryMock);
        return new AddDishHandler(repositoryMock.Object);
    }
}
