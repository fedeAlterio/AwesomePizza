using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Orders.CreateOrder;
using AwesomePizza.Test.TestHelpers;
using AwesomePizza.Web.Dto.Errors;
using AwesomePizza.Web.Endpoints.Orders.CreateOrder;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace AwesomePizza.Test.Web.Endpoints.Orders;
public class CreateOrderWebHandlerTests
{
    [Fact]
    public async Task ShouldReturnOk_IfCreateSuccess()
    {
        var orderId = MockData.OrderId();
        var handler = GetHandler(() => new CreateOrderSuccess(orderId));
        CreateOrderWebRequest createOrderWebRequest = new()
        {
            Dishes = [MockData.DishId().Value]
        };
        var response = await handler.Handle(createOrderWebRequest, default);
        var webResponse = response.As<Ok<CreateOrderWebResponse>>();
        webResponse.Value!.OrderId.Should().Be(orderId.Value);
    }

    [Fact]
    public async Task ShouldReturnBadRequest_IfSomeDishDontExist()
    {
        var dishId = MockData.DishId();
        var handler = GetHandler(() => new SomeDishesDontExist([dishId]));
        CreateOrderWebRequest createOrderWebRequest = new()
        {
            Dishes = [MockData.DishId().Value]
        };
        var response = await handler.Handle(createOrderWebRequest, default);
        var webResponse = response.As<BadRequest<ErrorResponse>>();
        webResponse.Value!.Errors.Should().HaveCount(1);
        webResponse.Value!.Errors.First().Should().Be(Error.DishNotFound(dishId));
    }

    [Fact]
    public async Task ShouldReturnBadRequest_IfNoDishesProvided()
    {
        var handler = GetHandler(() => new OneDishIsRequired());
        CreateOrderWebRequest createOrderWebRequest = new()
        {
            Dishes = [MockData.DishId().Value]
        };
        var response = await handler.Handle(createOrderWebRequest, default);
        var webResponse = response.As<BadRequest<ErrorResponse>>();
        webResponse.Value!.Errors.Should().HaveCount(1);
        webResponse.Value!.Errors.First().Should().Be(Error.AtLeastOneDishIsRequired());
    }


    CreateOrderWebHandler GetHandler(Func<CreateOrderResponse> response)
    {
        var mock = new Mock<IRequestSender<CreateOrderRequest, CreateOrderResponse>>();
        mock.Setup(x => x.Send(It.IsAny<CreateOrderRequest>(), default))
            .ReturnsAsync(response);

        return new(mock.Object);
    }
}
