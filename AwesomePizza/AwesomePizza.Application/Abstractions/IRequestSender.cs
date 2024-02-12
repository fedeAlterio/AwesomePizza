using MediatR;

namespace AwesomePizza.Application.Abstractions;

public interface IRequestSender<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    Task<TResponse> Send(TRequest request, CancellationToken cancellationToken = default);
}