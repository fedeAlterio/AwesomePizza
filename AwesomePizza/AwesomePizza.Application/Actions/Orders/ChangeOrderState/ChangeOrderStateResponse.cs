using AwesomePizza.Application.Actions.Orders.Common.CommonResponses;
using OneOf;

namespace AwesomePizza.Application.Actions.Orders.ChangeOrderState;

[GenerateOneOf]
public partial class ChangeOrderStateResponse : OneOfBase<ChangeOrderStateSuccesfully, OrderNotFound, OrderInWrongStateError>;
public record ChangeOrderStateSuccesfully;
