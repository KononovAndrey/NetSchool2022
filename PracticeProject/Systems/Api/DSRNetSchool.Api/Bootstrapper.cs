namespace DSRNetSchool.Api;

using DSRNetSchool.Api.Settings;
using DSRNetSchool.Services.Settings;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddApiSpecialSettings()
            ;

        return services;
    }
}
