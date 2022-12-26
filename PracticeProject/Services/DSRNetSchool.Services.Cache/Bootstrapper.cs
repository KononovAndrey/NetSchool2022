namespace DSRNetSchool.Services.Cache;

using DSRNetSchool.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = Settings.Load<CacheSettings>("Cache", configuration);
        services.AddSingleton(settings);

        services.AddSingleton<ICacheService, CacheService>();

        return services;
    }
}