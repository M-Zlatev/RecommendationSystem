namespace RS.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

using Application.Common.Interfaces;
using Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext>(serviceProvider => serviceProvider.GetRequiredService<RecommendationSystemDbContext>());
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<RecommendationSystemDbContext>());

        return services;
    }
}
