using Schola.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Schola.Shared.Queries;

internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();

            var handler = scope.ServiceProvider
                .GetRequiredService<IQueryHandler<IQuery<TResult>, TResult>>();

            return await handler.HandleAsync(query);
        }
        catch (Exception e)
        {
            throw new Exception($"Error dispatching query of type {query.GetType().Name}: {e.Message}");
        }
    }
}

