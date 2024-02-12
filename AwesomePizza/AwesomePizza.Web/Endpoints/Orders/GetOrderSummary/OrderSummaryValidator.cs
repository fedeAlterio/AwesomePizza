using FluentValidation;

namespace AwesomePizza.Web.Endpoints.Orders.GetOrderSummary;
public class OrderSummaryWebRequestValidator : AbstractValidator<OrderSummaryWebRequest>
{
    public OrderSummaryWebRequestValidator()
    {
        RuleFor(x => x.OrderId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}

