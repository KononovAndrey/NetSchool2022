namespace DSRNetSchool.Services.UserAccount;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddUserAccountService(this IServiceCollection services)
    {
        services.AddScoped<IUserAccountService, UserAccountService>();  // !!!  Обратите внимание, что UserAccount должен объявляться как SCOPED

        return services;
    }
}
