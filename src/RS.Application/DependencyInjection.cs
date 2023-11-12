namespace RS.Application;

#region Usings
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using FluentValidation;
#endregion

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        Assembly assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(assembly));

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}
