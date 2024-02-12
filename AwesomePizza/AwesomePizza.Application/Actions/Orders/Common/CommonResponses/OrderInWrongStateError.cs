using AwesomePizza.Models.Orders;

namespace AwesomePizza.Application.Actions.Orders.Common.CommonResponses;

public record OrderInWrongStateError(OrderId OrderId, OrderEventType State);