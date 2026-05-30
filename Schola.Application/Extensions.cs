
using Schola.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Schola.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        // services.AddSingleton<ISampleEntityFactory, SampleEntityFactory>();

        // services.Scan(b => b.FromAssemblies(typeof(ISampleEntityItemsPolicy).Assembly)
        //     .AddClasses(c => c.AssignableTo<ISampleEntityItemsPolicy>())
        //     .AsImplementedInterfaces()
        //     .WithSingletonLifetime());

        return services;
    }
}
