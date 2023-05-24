using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ThePreference.Application;

public static class ServiceInitializer
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        
        // services.AddAutoMapper(Assembly.GetExecutingAssembly());
        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        // services.AddMediatR(cfg => {
        //     cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        //     cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        //     cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
        //     cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        //     cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        //
        // });

        return services;
    }
}