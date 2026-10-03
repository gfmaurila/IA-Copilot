using System.Reflection;
using FluentValidation;
using Kit.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Kit.Application;

public static class ApplicationServiceCollectionExtensions
{
    /// <summary>
    /// Registers CQRS wiring: MediatR handlers, FluentValidation validators and the
    /// cross-cutting behaviors (validation -> logging -> unit of work).
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);
        });

        services.AddValidatorsFromAssembly(assembly, includeInternalTypes: true);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

        return services;
    }
}