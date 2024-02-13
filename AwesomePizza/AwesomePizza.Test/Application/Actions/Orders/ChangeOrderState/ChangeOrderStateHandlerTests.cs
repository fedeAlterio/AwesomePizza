using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Application.Actions.Orders.Common.CommonResponses;
using AwesomePizza.Models.Orders;
using AwesomePizza.Test.TestHelpers;
using FluentAssertions;
using MediatR;
using Moq;

namespace AwesomePizza.Test.Application.Actions.Orders.ChangeOrderState;
public class ChangeOrderStateHandlerTests
{
    [Fact]
    public async Task ShouldReturnOrderNotFound_IfThereIsntAnyOrderEvent()
    {
        var guid = MockData.GetGuids().First();
        var orderId = new OrderId(guid);
        var handler = GetHandler(orderEventRepository =>
        {
            orderEventRepository.Setup(x => x.GetLastEventForOrder(orderId, CancellationToken.None))
                                .ReturnsAsync((OrderEvent?)null);
        });

        var response = await handler.ChangeState(orderId, [], OrderEventType.Completed, default);
        response.Value.Should().BeOfType<OrderNotFound>();
    }

    [Fact]
    public async Task ShouldReturnOrderInWrongState_IfTransitionFromCurrentStateIsNotPossible()
    {
        await CheckWith([OrderEventType.Created], OrderEventType.InProgress, OrderEventType.InProgress);
        await CheckWith([OrderEventType.Created], OrderEventType.Completed, OrderEventType.InProgress);
        await CheckWith([OrderEventType.Created], OrderEventType.Rejected, OrderEventType.InProgress);

        await CheckWith([OrderEventType.InProgress], OrderEventType.Created,   OrderEventType.Completed);
        await CheckWith([OrderEventType.InProgress], OrderEventType.Rejected,  OrderEventType.Completed);
        await CheckWith([OrderEventType.InProgress], OrderEventType.Completed, OrderEventType.Completed);

        await CheckWith([OrderEventType.Created], OrderEventType.Completed,  OrderEventType.Rejected);
        await CheckWith([OrderEventType.Created], OrderEventType.InProgress, OrderEventType.Rejected);
        await CheckWith([OrderEventType.Created], OrderEventType.Rejected,   OrderEventType.Rejected);

        async Task CheckWith(IEnumerable<OrderEventType> source, OrderEventType current, OrderEventType destination)
        {
            var guid = MockData.GetGuids().First();
            var orderId = new OrderId(guid);
            var handler = GetHandler(orderEventRepository =>
            {
                orderEventRepository.Setup(x => x.GetLastEventForOrder(orderId, CancellationToken.None))
                                    .ReturnsAsync(new OrderEvent
                                    {
                                        OrderId = orderId,
                                        Type = current,
                                        Id = new(MockData.GetGuids().Skip(1).First()),
                                        DateUtc = new DateTime(2024, 02, 1)
                                    });
            });

            var response = await handler.ChangeState(orderId, source, destination, default);
            response.Value.Should().BeOfType<OrderInWrongStateError>();
        }
    }

     [Fact]
    public async Task ShouldReturnSuccess_IfTransitionFromCurrentIsPossible()
    {
        await CheckWith([OrderEventType.Created],    OrderEventType.Created,    OrderEventType.InProgress);
        await CheckWith([OrderEventType.InProgress], OrderEventType.InProgress, OrderEventType.Completed);
        await CheckWith([OrderEventType.Created],    OrderEventType.Created,  OrderEventType.Rejected);

        async Task CheckWith(IEnumerable<OrderEventType> source, OrderEventType current, OrderEventType destination)
        {
            var guid = MockData.GetGuids().First();
            var orderId = new OrderId(guid);
            var handler = GetHandler(orderEventRepository =>
            {
                orderEventRepository.Setup(x => x.GetLastEventForOrder(orderId, CancellationToken.None))
                                    .ReturnsAsync(new OrderEvent
                                    {
                                        OrderId = orderId,
                                        Type = current,
                                        Id = new(MockData.GetGuids().Skip(1).First()),
                                        DateUtc = new DateTime(2024, 02, 1)
                                    });
            });

            var response = await handler.ChangeState(orderId, source, destination, default);
            response.Value.Should().BeOfType<ChangeOrderStateSuccesfully>();
        }
    }

    public ChangeOrderStateHandler GetHandler(Action<Mock<IOrderEventRepository>> orderEventRepositoryConfig)
    {
        var mock = new Mock<IOrderEventRepository>(MockBehavior.Strict);
        
        orderEventRepositoryConfig(mock);
        return new(mock.Object, new());
    }
}
