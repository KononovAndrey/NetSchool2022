namespace DSRNetSchool.Services.Authors;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddAuthorService(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorService, AuthorService>();

        return services;
    }
}
