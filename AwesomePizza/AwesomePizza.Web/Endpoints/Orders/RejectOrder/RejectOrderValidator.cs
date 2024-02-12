using FluentValidation;

namespace AwesomePizza.Web.Endpoints.Orders.RejectOrder;
public class RejectOrderWebRequestValidator : AbstractValidator<RejectOrderWebRequest>
{
    public RejectOrderWebRequestValidator()
    {
        RuleFor(x => x.OrderId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}

