using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Application.Actions.Orders.CreateOrder;
using AwesomePizza.Models.Dishes;
using AwesomePizza.Models.Orders;
using AwesomePizza.Test.TestHelpers;
using FluentAssertions;
using Moq;

namespace AwesomePizza.Test.Application.Actions.Orders;
public class CreateOrderTests
{
    [Fact]
    public async Task ShouldReturnOneDishIsRequired_IfThereAreNoDishes()
    {
        await CheckWith(null);
        await CheckWith([]);

        async Task CheckWith(List<DishId>? dishes)
        {
            var handler = GetHandler();
            var request = new CreateOrderRequest { Dishes = dishes! };
            var response = await handler.Handle(request, CancellationToken.None);
            response.Value.Should().BeOfType<OneDishIsRequired>();
        }
    }

    [Fact]
    public async Task ShouldReturnSomeDishesDontExist_IfSomeDishDontExist()
    {
        var allDishIds = MockData.GetGuids().Select(x => new DishId(x)).ToList();
        var existentDishesIds = allDishIds.Take(2).ToList();
        var existentDishes = existentDishesIds.Select(x => MockData.CreateDish(x.Value)).ToList();

        var handler = GetHandler((dishRepository, _, _) =>
        {
            dishRepository.Setup(x => x.FindById(allDishIds, default))
                          .ReturnsAsync(existentDishes);
        });

        var request = new CreateOrderRequest
        {
            Dishes = allDishIds
        };

        var response = await handler.Handle(request, default);
        response.Value.As<SomeDishesDontExist>()
                .NotExistentDishes.Should().BeEquivalentTo(allDishIds.Except(existentDishesIds));
    }

    [Fact]
    public async Task ShouldBeSuccessWithCreatedType_IfNotDuplicatedDishes()
    {
        var allDishIds = MockData.GetGuids().Select(x => new DishId(x)).ToList();
        var existentDishesIds = allDishIds;
        var existentDishes = existentDishesIds.Select(x => MockData.CreateDish(x.Value)).ToList();

        Order? passedOrder = null;
        OrderEvent? passedOrderEvent = null;
        var handler = GetHandler((dishRepository, orderRepository, orderEventRepository) =>
        {
            dishRepository.Setup(x => x.FindById(allDishIds, default))
                          .ReturnsAsync(existentDishes);

            orderRepository.Setup(x => x.AddOrder(It.IsAny<Order>()))
                           .Callback((Order order) => passedOrder = order);

            orderEventRepository.Setup(x => x.AddOrderEvent(It.IsAny<OrderEvent>()))
                                .Callback((OrderEvent orderEvent) => passedOrderEvent = orderEvent);
        });

        var request = new CreateOrderRequest
        {
            Dishes = allDishIds
        };

        var response = await handler.Handle(request, default);
        response.Value.Should().BeOfType<CreateOrderSuccess>();
        passedOrder.Should().NotBeNull();
        passedOrderEvent.Should().NotBeNull();
        passedOrder!.Id.Should().Be(passedOrderEvent!.OrderId);
        passedOrderEvent.Type.Should().Be(OrderEventType.Created);
    }


    delegate void HandlerConfiguration(Mock<IDishRepository> dishRepositoryConfig,
                                       Mock<IOrderRepository> orderRepositoryConfig,
                                       Mock<IOrderEventRepository> orderEventRepositoryMock);

    static CreateOrderHandler GetHandler(HandlerConfiguration? configuration = null)
    {
        var dishRepositoryMock = new Mock<IDishRepository>(MockBehavior.Strict);
        var orderRepositoryMock = new Mock<IOrderRepository>(MockBehavior.Strict);
        var orderEventRepositoryMock = new Mock<IOrderEventRepository>(MockBehavior.Strict);

        configuration?.Invoke(dishRepositoryMock, orderRepositoryMock, orderEventRepositoryMock);
        return new CreateOrderHandler(orderRepositoryMock.Object, dishRepositoryMock.Object, orderEventRepositoryMock.Object);
    }
}
