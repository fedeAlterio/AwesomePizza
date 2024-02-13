using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace AwesomePizza.Application.Events.Helpers;
public class EventAggregator
{
    readonly ConcurrentQueue<INotification> _events = new();

    public void AddEvent(INotification @event) => _events.Enqueue(@event);

    public bool TryGetNextEvent([NotNullWhen(true)] out INotification? @event) => _events.TryDequeue(out @event);
}
