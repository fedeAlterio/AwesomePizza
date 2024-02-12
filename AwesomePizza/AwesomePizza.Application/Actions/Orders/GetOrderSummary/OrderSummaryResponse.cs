using AwesomePizza.Application.Actions.Orders.Common.CommonResponses;
using AwesomePizza.Models.Orders;
using MediatR;
using OneOf;

namespace AwesomePizza.Application.Actions.Orders.GetOrderSummary;

[GenerateOneOf]
public partial class OrderSummaryResponse : OneOfBase<OrderSummary, OrderNotFound>;
