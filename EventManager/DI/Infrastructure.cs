using EventManager.Data;
using EventManager.Interfaces;
using EventManager.Services;

namespace EventManager.DI;

public static partial class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IEventRepository, EventRepository>();
        services.AddScoped<IEventService, EventService>();

        return services;
    }
}
