namespace DSRNetSchool.Api.Configuration;

using DSRNetSchool.Common;

public static class ControllerAndViewsConfiguration
{
    public static IServiceCollection AddAppControllerAndViews(this IServiceCollection services)
    {
        services
            .AddRazorPages();

        services
            .AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.SetDefaultSettings())
            ;

        return services;
    }

    public static IEndpointRouteBuilder UseAppControllerAndViews(this IEndpointRouteBuilder app)
    {
        app.MapRazorPages();
        app.MapControllers();

        return app;
    }
}