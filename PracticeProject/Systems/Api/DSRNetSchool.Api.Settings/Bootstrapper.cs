namespace DSRNetSchool.Api.Settings;

using DSRNetSchool.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddApiSpecialSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<ApiSpecialSettings>("ApiSpecial", configuration);
        services.AddSingleton(settings);

        return services;
    }
}