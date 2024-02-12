using AwesomePizza.Models.Orders;
using OneOf;

namespace AwesomePizza.Application.Actions.Orders.LastOrderToBeCompleted;


[GenerateOneOf]
public partial class LastOrderToBeCompletedResponse : OneOfBase<LastOrderToBeCompletedInfo, LastOrderToBeCompletedNotFound>;

public class LastOrderToBeCompletedInfo
{
    public required OrderEvent LastOrderEvent { get; init; }
}

public class LastOrderToBeCompletedNotFound;
