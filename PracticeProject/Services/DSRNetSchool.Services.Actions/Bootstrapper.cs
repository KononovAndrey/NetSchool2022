namespace DSRNetSchool.Services.Actions;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddActions(this IServiceCollection services)
    {
        services.AddSingleton<IAction, Action>();

        return services;
    }
}
