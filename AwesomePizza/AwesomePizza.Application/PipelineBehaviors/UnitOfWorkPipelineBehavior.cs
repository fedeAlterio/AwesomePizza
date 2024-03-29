﻿using System.Reflection;
using System.Transactions;
using AwesomePizza.Application.Abstractions;
using AwesomePizza.Application.Actions.Abstractions;
using AwesomePizza.Application.Events.Helpers;
using MediatR;

namespace AwesomePizza.Application.PipelineBehaviors;
public class UnitOfWorkPipelineBehavior<TRequest, TResponse>(IDbContext appDbContext, EventAggregator eventAggregator, IPublisher publisher) : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand
{
    int _isNested;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (Interlocked.CompareExchange(ref _isNested, 1, 0) == 1)
            return await next();

        var isolationLevelAttribute = request.GetType()
                                             .GetCustomAttribute<IsolationLevelAttribute>();

        var options = new TransactionOptions
        {
            IsolationLevel = isolationLevelAttribute?.IsolationLevel ?? IsolationLevel.ReadCommitted
        };

        using var transactionScope = new TransactionScope(TransactionScopeOption.Required, options, TransactionScopeAsyncFlowOption.Enabled);
        var ret = await next();
        await appDbContext.SaveChangesAsync(cancellationToken);
        transactionScope.Complete();
        await PublishAllEvents(cancellationToken);
        return ret;
    }

    async Task PublishAllEvents(CancellationToken cancellationToken)
    {
        while (eventAggregator.TryGetNextEvent(out var @event))
        {
            await publisher.Publish(@event, cancellationToken);
        }
    }
}
