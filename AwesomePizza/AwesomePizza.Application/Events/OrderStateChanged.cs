using AwesomePizza.Models.Orders;
using MediatR;

namespace AwesomePizza.Application.Events;

public record OrderStateChanged(OrderId OrderId) : INotification;

