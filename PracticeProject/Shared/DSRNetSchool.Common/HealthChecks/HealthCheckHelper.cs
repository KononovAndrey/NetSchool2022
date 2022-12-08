namespace DSRNetSchool.Common;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

public static class HealthCheckHelper
{
    public static async Task WriteHealthCheckResponse(HttpContext context, HealthReport report)
    {
        context.Response.ContentType = "application/json";
        var response = new HealthCheck()
        {
            OverallStatus = report.Status.ToString(),
            TotalDuration = report.TotalDuration.TotalSeconds.ToString("0:0.00"),
            HealthChecks = report.Entries.Select(x => new HealthCheckItem
            {
                Status = x.Value.Status.ToString(),
                Component = x.Key,
                Description = x.Value.Description ?? "",
                Duration = x.Value.Duration.TotalSeconds.ToString("0:0.00")
            }),

        };

        await context.Response.WriteAsync(text: JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
    }
}
