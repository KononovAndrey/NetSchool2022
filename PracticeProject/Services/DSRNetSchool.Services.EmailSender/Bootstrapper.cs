namespace DSRNetSchool.Services.EmailSender;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddEmailSender(this IServiceCollection services)
    {
        services.AddSingleton<IEmailSender, EmailSender>();

        return services;
    }
}
