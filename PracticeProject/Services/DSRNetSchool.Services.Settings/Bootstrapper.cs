namespace DSRNetSchool.Services.Settings;

using DSRNetSchool.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddMainSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<MainSettings>("Main", configuration);
        services.AddSingleton(settings);

        return services;
    }

    public static IServiceCollection AddSwaggerSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<SwaggerSettings>("Swagger", configuration);
        services.AddSingleton(settings);

        return services;
    }
}