namespace EventManager.DI; 

public static partial class DependencyInjectionExtensions
{
    public static IServiceCollection AddVisualization(this IServiceCollection services)
    {
        // Регистрация Swagger для документации API
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}
