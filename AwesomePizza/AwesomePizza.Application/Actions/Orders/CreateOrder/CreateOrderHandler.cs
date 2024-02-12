using AwesomePizza.Application.Abstractions.Repositories;
using AwesomePizza.Models.Common;
using AwesomePizza.Models.Orders;
using MediatR;

namespace AwesomePizza.Application.Actions.Orders.CreateOrder;
public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
{
    readonly IOrderRepository _orderRepository;
    readonly IDishRepository _dishRepository;
    readonly IOrderEventRepository _orderEventRepository;

    public CreateOrderHandler(IOrderRepository orderRepository,
                              IDishRepository dishRepository,
                              IOrderEventRepository orderEventRepository)
    {
        _orderRepository = orderRepository;
        _dishRepository = dishRepository;
        _orderEventRepository = orderEventRepository;
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var dishesIds = request.Dishes;
        if (dishesIds.IsNullOrEmpty())
            return new OneDishIsRequired();

        var dishes = await _dishRepository.FindById(dishesIds, cancellationToken);
        var notExistentDishes = dishesIds.Except(dishes.Select(x => x.Id))
                                         .ToList();

        if (notExistentDishes.Any())
            return new SomeDishesDontExist(notExistentDishes);

        var dishesWithCorrectQuantities = dishesIds.Select(id => dishes.First(dish => dish.Id == id))
                                                   .ToList();

        
        var order = Order.Create(dishesWithCorrectQuantities);
        _orderRepository.AddOrder(order);

        var orderEvent = OrderEvent.CreateForNewOrder(order.Id);
        _orderEventRepository.AddOrderEvent(orderEvent);

        return new CreateOrderSuccess(order.Id);
    }
}
