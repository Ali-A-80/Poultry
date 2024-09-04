using Poultry.Persistance.Lifetimes;
using System.Reflection;

namespace Endpoint.API.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServicesWithTheirLifetimes(this IServiceCollection services, Action<DependencyInjectionOptions> configureDependencies)
    {
        var dependencyInjectionOptions = new DependencyInjectionOptions();
        configureDependencies.Invoke(dependencyInjectionOptions);

        dependencyInjectionOptions.LoadAssembelies();

        services.AddServicesWithSingletonLifetime(dependencyInjectionOptions.Assemblies, new Type[] { typeof(ISingletonLifetime) })
            .AddServicesWithTransienLifetime(dependencyInjectionOptions.Assemblies, new Type[] { typeof(ITransientLifetime) })
            .AddServicesWithScopedLifetime(dependencyInjectionOptions.Assemblies, new Type[] { typeof(IScopedLifetime) });

        return services;
    }

    private static IServiceCollection AddServicesWithSingletonLifetime(this IServiceCollection services, IEnumerable<Assembly> assemblies, IEnumerable<Type> types)
    {
        services.Scan(sourceSelecetor => sourceSelecetor.FromAssemblies(assemblies)
            .AddClasses(type => type.AssignableToAny(types))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }

    private static IServiceCollection AddServicesWithScopedLifetime(this IServiceCollection services, IEnumerable<Assembly> assemblies, IEnumerable<Type> types)
    {
        services.Scan(sourceSelector => sourceSelector.FromAssemblies(assemblies)
            .AddClasses(type => type.AssignableToAny(types))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }

    private static IServiceCollection AddServicesWithTransienLifetime(this IServiceCollection services, IEnumerable<Assembly> assemblies, IEnumerable<Type> types)
    {
        services.Scan(sourceSelector => sourceSelector.FromAssemblies(assemblies)
            .AddClasses(type => type.AssignableToAny(types))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}
