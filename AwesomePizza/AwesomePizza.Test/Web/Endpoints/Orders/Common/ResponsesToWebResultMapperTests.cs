using AwesomePizza.Application.Actions.Orders.ChangeOrderState;
using AwesomePizza.Application.Actions.Orders.Common.CommonResponses;
using AwesomePizza.Models.Orders;
using AwesomePizza.Test.TestHelpers;
using AwesomePizza.Web.Dto.Errors;
using AwesomePizza.Web.Endpoints.Orders.Common;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AwesomePizza.Test.Web.Endpoints.Orders.Common;
public class ResponsesToWebResultMapperTests
{
    [Fact]
    public void ShouldReturnOk_IfChangeStateSuccess()
    {
        ChangeOrderStateResponse response = new ChangeOrderStateSuccesfully();
        response.ToResult().Should().BeOfType<Ok>();
    }

    [Fact]
    public void ShouldReturnOrderWrongStateError_IfChangeStateIsWrongState()
    {
        var guid = MockData.GetGuids().First();
        var types = Enum.GetValues<OrderEventType>();
        foreach (var type in types)
        {
            var orderId = new OrderId(guid);
            ChangeOrderStateResponse response = new OrderInWrongStateError(orderId, type);
            var errorResponse = response.ToResult().As<BadRequest<ErrorResponse>>().Value;
            errorResponse.Should().NotBeNull();
            errorResponse!.Errors.Should().HaveCount(1);
            errorResponse.Errors.First().Should().Be(Error.OrderInWrongState(orderId, type));
        }
    }

    [Fact]
    public void ShouldReturnNotFound_IfChangeStateIsOrderNotFound()
    {
        var guid = MockData.GetGuids().First();
        var orderId = new OrderId(guid);
        ChangeOrderStateResponse response = new OrderNotFound(orderId);
        var errorResponse = response.ToResult().As<NotFound<ErrorResponse>>().Value;
        errorResponse.Should().NotBeNull();
        errorResponse!.Errors.Should().HaveCount(1);
        errorResponse.Errors.First().Should().Be(Error.OrderNotFound(orderId));
    }
}
