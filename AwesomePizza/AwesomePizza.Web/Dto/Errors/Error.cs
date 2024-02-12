using AwesomePizza.Application.Actions.Orders.Common.CommonResponses;
using AwesomePizza.Models.Dishes;
using AwesomePizza.Models.Orders;

namespace AwesomePizza.Web.Dto.Errors;

public record Error(string Message, string ErrorCode)
{
    public static Error Validation(string message) => new(message, ErrorCodes.VALIDATION_ERROR);
    public static Error FieldValidation(string message) => new(message, ErrorCodes.FIELD_VALIDATION_ERROR);
    public static Error Generic(string message) => new(message, ErrorCodes.GENERIC);
    public static Error OrderNotFound(OrderId orderId) => new($"Order not found {orderId.Value}", ErrorCodes.ORDER_NOT_FOUND);
    public static Error OrderInWrongState(OrderId orderId, OrderEventType type) => new($"Order {orderId.Value} not found {type}", ErrorCodes.ORDER_WRONG_STATE);
    public static Error DishNotFound(DishId dishId) => new($"Dish not found {dishId.Value}", ErrorCodes.DISH_NOT_FOUND);
    public static Error AtLeastOneDishIsRequired() => new("At least one dish is required", ErrorCodes.AT_LEAST_ONE_DISH_IS_REQUIRED);
}