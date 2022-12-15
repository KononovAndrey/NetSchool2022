namespace DSRNetSchool.Services.Books;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddBookService(this IServiceCollection services)
    {
        services.AddSingleton<IBookService, BookService>();

        return services;
    }
}
