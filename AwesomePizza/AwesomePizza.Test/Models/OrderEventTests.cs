using AwesomePizza.Models.Orders;
using FluentAssertions;

namespace AwesomePizza.Test.Models;
public class OrderEventTests
{
    [Fact]
    public void OrderEventType_ShouldBeOrderedByProgress()
    {
        OrderEventType[] orderedStates =
        [
            OrderEventType.Created,
            OrderEventType.InProgress,
        ];

        orderedStates.OrderBy(x => (int)x).Should().BeEquivalentTo(orderedStates, "This is used inside a query");
    }
}
