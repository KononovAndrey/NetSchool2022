namespace DSRNetSchool.Identity.Configuration;

using Serilog;

/// <summary>
/// Logger Configuration
/// </summary>
public static class LoggerConfiguration
{
    /// <summary>
    /// Add logger
    /// </summary>
    public static void AddAppLogger(this WebApplicationBuilder builder)
    {
        var logger = new Serilog.LoggerConfiguration()
            .Enrich.WithCorrelationIdHeader()
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog(logger, true);
    }
}